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
            EditRoom editRoom = new EditRoom((Room)dataGridRooms.SelectedItem, _roomController);
            editRoom.Show();
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
        }

    }
}
