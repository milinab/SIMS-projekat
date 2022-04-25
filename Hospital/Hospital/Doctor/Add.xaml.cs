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
using Hospital.Model;

namespace Hospital.Doctor {
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Add : Page {

        private DoctorWindow _doctorWindow;
        private AppointmentController _appointmentController;
        public Add(DoctorWindow doctorWindow, AppointmentController appointmentController) {
            _doctorWindow = doctorWindow;
            _appointmentController = appointmentController;
            InitializeComponent();
        }
        private void RoomClick(object sender, RoutedEventArgs e) {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void Confirm(object sender, RoutedEventArgs e) {
            DateTime _date = datePicker.SelectedDate.Value;
            string _time = timeBox.Text;
            string[] _timeParts = _time.Split(':');
            _date += new TimeSpan(int.Parse(_timeParts[0]), int.Parse(_timeParts[1]), 0);
            string _dur = duration.Text;
            string[] _durationParts = _dur.Split(':');
            TimeSpan _duration = new TimeSpan(int.Parse(_durationParts[0]), int.Parse(_durationParts[1]), 0);
            Appointment appointment = new Appointment {
                Date = _date,
                Duration = _duration
            };
            _appointmentController.Create(appointment);
            _doctorWindow.BackToDoctorWindow();
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            _doctorWindow.BackToDoctorWindow();
        }
    }
}