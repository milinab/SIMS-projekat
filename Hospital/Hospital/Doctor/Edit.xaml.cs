using System;
using System.Collections.Generic;
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

namespace Hospital.Doctor {
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window {

        private Model.Appointment _appointment;
        private Model.AppointmentHandler _appointmentHandler;
        public Edit(Model.Appointment appointment, Model.AppointmentHandler appointmentHandler) {
            InitializeComponent();
            _appointment = appointment;
            _appointmentHandler = appointmentHandler;
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
            DateTime _editDate = datepicker.SelectedDate.Value + new TimeSpan(Int32.Parse(timeParts[0]), Int32.Parse(timeParts[1]), 0);

            string _duration = duration.Text;
            string[] durationParts = _duration.Split(':');
            TimeSpan _editDuration = new TimeSpan(Int32.Parse(durationParts[0]), Int32.Parse(durationParts[1]), 0);
            Model.Appointment _appointment = new Model.Appointment {
                Id = Int32.Parse(id.Text),
                Date = _editDate,
                Duration = _editDuration
            };
            _appointmentHandler.Edit(_appointment);
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
