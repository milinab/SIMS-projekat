using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Hospital.Exceptions;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for Renovate.xaml
    /// </summary>
    public partial class Renovate : Page
    {
        private App _app;
        private readonly RoomOccupancy _roomOccupancy;
        private readonly AppointmentController _appointmentController;

        public Renovate(RoomOccupancy roomOccupancy, AppointmentController appointmentController)
        {
            _app = Application.Current as App;
            _roomOccupancy = roomOccupancy;
            _appointmentController = appointmentController;
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Now;
            List<Room>roomList = _app._roomController.Read();
            ObservableCollection<Room> rooms = new ObservableCollection<Room>(roomList);
            ObservableCollection<String> roomNames = new ObservableCollection<string>();
            foreach (Room room in rooms)
            {
                roomNames.Add(room.Name);
            }
            roomComboBox.ItemsSource = roomNames;
        }

        private void Schedule(object sender, RoutedEventArgs e)
        {
            DateTime _date = datePicker.SelectedDate.Value;
            string _room = roomComboBox.Text;
            TimeSpan interval = new TimeSpan(23, 59, 59);
            List<Room>roomList = _app._roomController.Read();
            ObservableCollection<Room> rooms = new ObservableCollection<Room>(roomList);
            Room tempRoom = new Room();
            foreach (Room room in rooms)
            {
                if (room.Name.Equals(_room))
                {
                    tempRoom = room;
                }
            }

            Appointment appointment = new Appointment(tempRoom, _date, interval);
            try
            {
                _appointmentController.Create(appointment);
            }
            catch (AppointmentException exp)
            { 
                validationDateRoom.Visibility = Visibility.Visible;
                return;
            }
            _roomOccupancy.BackToRoomOccupancy();
        }

        private void CancelRenovateClick(object sender, RoutedEventArgs e)
        {
            {
                _roomOccupancy.BackToRoomOccupancy();
                
            }
        }

        public Renovate()
        {
            InitializeComponent();
        }

        private void EquipmentClick(object sender, RoutedEventArgs e)
        {
            EquipmentWindow equipmentWindow = new View.ManagerView.EquipmentWindow(_app._equipmentController);
            equipmentWindow.Show();
        }
        private void RoomClick(object sender, RoutedEventArgs e)
        {

            ManagerWindow roomWindow = new View.ManagerView.ManagerWindow(_app._roomController);
            roomWindow.Show();
        }

        private void OccupancyClick(object sender, RoutedEventArgs e)
        {
            RoomOccupancy roomOccupancy = new View.ManagerView.RoomOccupancy(_app._appointmentController, _app._roomController);
            roomOccupancy.Show();
        }
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            ManagerHomeWindow managerHomeWindow = new ManagerHomeWindow();
            managerHomeWindow.Show();
        }
        private void MedicineClick(object sender, RoutedEventArgs e)
        {
            MedicineWindow medicine = new MedicineWindow(_app._medicineController);
            medicine.Show();
        }
        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
        }
        private void SurveyClick(object sender, RoutedEventArgs e)
        {
            SurveySelect surveySelect = new SurveySelect();
            surveySelect.Show();
        }
    }
}
