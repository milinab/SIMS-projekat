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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.View.DoctorView {
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Add : Page
    {

        private App _app;
        private readonly Appointments _appointments;
        
        public Add(Appointments appointments)
        {
            _app = Application.Current as App;
            _appointments = appointments;
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Now;
            ObservableCollection<Room> rooms = _app._roomController.Read();
            ObservableCollection<String> roomNames = new ObservableCollection<string>();
            foreach (var room in rooms)
            {
                roomNames.Add(room.Name);
            }

            RoomListBox.ItemsSource = roomNames;
            //equipmentListBox.ItemsSource =
        }
        private void RoomClick(object sender, RoutedEventArgs e) {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void Confirm(object sender, RoutedEventArgs e) {
            DateTime date = DatePicker.SelectedDate.Value;
            string time = TimePicker.Text;
            string[] timeParts = time.Split(':');
            date += new TimeSpan(int.Parse(timeParts[0]), int.Parse(timeParts[1]), 0);
            string dur = Duration.Text;
            string[] durationParts = dur.Split(':');
            TimeSpan duration = new TimeSpan(int.Parse(durationParts[0]), int.Parse(durationParts[1]), 0);
            Doctor tempDoctor = _app._doctorController.ReadById(1);
            Patient tempPatient = _app._patientController.ReadById(1);
            string roomName = RoomListBox.SelectedItem.ToString();
            ObservableCollection<Room> rooms = _app._roomController.Read();
            Room tempRoom = new Room();
            foreach (var room in rooms)
            {
                if (room.Name.Equals(roomName))
                {
                    tempRoom = room;
                }
            }

            Appointment appointment = new Appointment(date, duration, tempDoctor, tempPatient, tempRoom);

            _app._appointmentController.Create(appointment);
            _appointments.SwitchPage();
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            _appointments.SwitchPage();
        }
    }
}