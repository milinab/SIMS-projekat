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
        }

        private void RoomClick(object sender, RoutedEventArgs e) {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void Confirm(object sender, RoutedEventArgs e) {
            Model.Appointment _appointment = new Model.Appointment{ Id = Int32.Parse(id.Text), Date = datepicker.SelectedDate.Value };
            _appointmentHandler.Edit(_appointment);
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
