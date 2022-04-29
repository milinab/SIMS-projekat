using System;
using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.View.DoctorView {
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window {

        private readonly Appointment _appointment;
        private AppointmentController _appointmentController;
        public Edit(Appointment appointment, AppointmentController appointmentController) {
            InitializeComponent();
            _appointment = appointment;
            _appointmentController = appointmentController;
            id.Text = (_appointment.Id).ToString();
            datepicker.SelectedDate = _appointment.Date;
            int hour = _appointment.Date.Hour;
            int minute = _appointment.Date.Minute;
            String hourString = hour.ToString();
            String minuteString = minute.ToString();
            timebox.Text = hourString + ":" + minuteString;
            int hours = _appointment.Duration.Hours;
            int minutes = _appointment.Duration.Minutes;
            duration.Text = hours.ToString() + ":" + minute.ToString();
        }

        private void RoomClick(object sender, RoutedEventArgs e) {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void Confirm(object sender, RoutedEventArgs e) {
            string _time = timebox.Text;
            string[] timeParts = _time.Split(':');
            DateTime _editDate = datepicker.SelectedDate.Value + new TimeSpan(int.Parse(timeParts[0]), int.Parse(timeParts[1]), 0);

            string _duration = duration.Text;
            string[] durationParts = _duration.Split(':');
            TimeSpan _editDuration = new TimeSpan(int.Parse(durationParts[0]), int.Parse(durationParts[1]), 0);
            Appointment _appointment = new Appointment {
                Id = int.Parse(id.Text),
                Date = _editDate,
                Duration = _editDuration
            };
            _appointmentController.Edit(_appointment);
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
