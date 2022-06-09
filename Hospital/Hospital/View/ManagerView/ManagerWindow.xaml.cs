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
        private App _app;
        private readonly object _content;
        private readonly RoomController _roomController;
        private readonly EquipmentController _equipmentController;
        private readonly AppointmentController _appointmentController;


        public ManagerWindow(RoomController roomController)
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _content = Content;
            _roomController = roomController;
            dataGridRooms.ItemsSource = _roomController.Read();

        }



        private void EditRoomClick(object sender, RoutedEventArgs e)
        {
           
            Room room = dataGridRooms.SelectedValue as Room;
            if (room == null)
            {
                validacija.Visibility = Visibility.Visible;
                return;
            }

            validacija.Visibility = Visibility.Hidden;
            var editRoom = new EditRoom(room, this);
            Content = editRoom;

        }



        private void AddRoomsClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.AddRoomWindow addRoomWindow = new View.ManagerView.AddRoomWindow(this, _roomController);
            addRoomWindow.ShowDialog();
            Close();


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
        public void BackToManagerWindow()
        {
            Content = _content;
            refresh();
        }
        private void refresh()
        {
            dataGridRooms.ItemsSource = _roomController.Read();
        }
        private void EquipmentClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.EquipmentWindow equipmentWindow = new View.ManagerView.EquipmentWindow(_app._equipmentController);
            equipmentWindow.Show();
            Close();
        }
        private void RoomClick(object sender, RoutedEventArgs e)
        {

            View.ManagerView.ManagerWindow roomWindow = new View.ManagerView.ManagerWindow(_app._roomController);
            roomWindow.Show();
            Close();
        }

        private void OccupancyClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.RoomOccupancy roomOccupancy = new View.ManagerView.RoomOccupancy(_app._appointmentController, _app._roomController);
            roomOccupancy.Show();
            Close();
        }
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.ManagerHomeWindow managerHomeWindow = new ManagerHomeWindow();
            managerHomeWindow.Show();
            Close();
        }
        private void MedicineClick(object sender, RoutedEventArgs e)
        {
            MedicineWindow medicine = new MedicineWindow(_app._medicineController);
            medicine.Show();
            Close();
        }

        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            Close();
        }
        private void SurveyClick(object sender, RoutedEventArgs e)
        {
            SurveySelect surveySelect = new SurveySelect();
            surveySelect.Show();
            Close();
        }


    }
}
