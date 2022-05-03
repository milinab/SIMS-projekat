using Hospital.Controller;
using Hospital.Model;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.ManagerView
{




    public partial class ManagerWindow : Window
    {
        private App app;
        private readonly object _content;
        private readonly RoomController _roomController;
        private readonly EquipmentController _equipmentController;
        private readonly AppointmentController _appointmentController;


        public ManagerWindow(RoomController roomController)
        {
            InitializeComponent();
            _content = Content;
            _roomController = roomController;
            dataGridRooms.ItemsSource = _roomController.Read();

        }



        private void EditRoomClick(object sender, RoutedEventArgs e)
        {
           
            Room room = dataGridRooms.SelectedValue as Room;
            //int roomId = room.Id;
            var editRoom = new EditRoom(room, this);
            Content = editRoom;

        }



        private void AddRoomsClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.AddRoomWindow addRoomWindow = new View.ManagerView.AddRoomWindow(this, _roomController);
            addRoomWindow.ShowDialog();


        }


        private void DeleteRoom(object sender, RoutedEventArgs e)
        {
            if (dataGridRooms.SelectedItem != null)
            {
                Room room = dataGridRooms.SelectedValue as Room;
                _roomController.Delete(room.Id);
            }
            else
            {
                MessageBox.Show("You must select a row first", "Warning");
            }
        }
        private void HomeClick(object sender, RoutedEventArgs e)
        {

        }
        public void BackToManagerWindow()
        {
            Content = _content;
            refresh();
        }
        public void refresh()
        {
            dataGridRooms.ItemsSource = _roomController.Read();
        }
    }
}
