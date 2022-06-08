using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for Renovate.xaml
    /// </summary>
    public partial class Renovate : Page
    {
        private App _app;
        private readonly RoomOccupancy _roomOccupancy;
        //private RoomController _roomController;
        private AppointmentController _appointmentController;

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
            List<Appointment> appointmentList = _app._appointmentController.Read();
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>(appointmentList);
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

            bool nesto = false;

            foreach (Appointment appointment1 in appointments.ToList())
            {
                if (DateTime.Compare(appointment1.Date, appointment.Date) == 0)
                {
                    if (appointment.RoomId == appointment1.RoomId)
                    {
                        MessageBox.Show("Ne moze!");
                        nesto = true;
                    }
                }
            }
            if(nesto == false)
            {

                if (roomComboBox.Text.Equals(""))
                {
                    validationRoom.Visibility = Visibility.Visible;
                    validationDate.Visibility = Visibility.Hidden;
                    return;
                }


                _appointmentController.Create(appointment);
                _roomOccupancy.BackToRoomOccupancy();
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

        private void roomComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EquipmentClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.EquipmentWindow equipmentWindow = new View.ManagerView.EquipmentWindow(_app._equipmentController);
            equipmentWindow.Show();
        }
        private void RoomClick(object sender, RoutedEventArgs e)
        {

            View.ManagerView.ManagerWindow roomWindow = new View.ManagerView.ManagerWindow(_app._roomController);
            roomWindow.Show();
        }

        private void OccupancyClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.RoomOccupancy roomOccupancy = new View.ManagerView.RoomOccupancy(_app._appointmentController, _app._roomController);
            roomOccupancy.Show();
        }
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.ManagerHomeWindow managerHomeWindow = new ManagerHomeWindow();
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
