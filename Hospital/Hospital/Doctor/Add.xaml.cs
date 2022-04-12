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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.Doctor {
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Add : Page {

        private DoctorWindow doctorWindow;
        private Model.AppointmentHandler appointmentHandler;
        public Add(DoctorWindow doctorWindow, Model.AppointmentHandler appointmentHandler) {
            this.doctorWindow = doctorWindow;
            this.appointmentHandler = appointmentHandler;
            InitializeComponent();
        }
        private void RoomClick(object sender, RoutedEventArgs e) {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void Confirm(object sender, RoutedEventArgs e) {
            //String time = timebox.Text;
            //Model.Room room = new Model.Room();
            int _id = Int32.Parse(id.Text);
            DateTime _date = datepicker.SelectedDate.Value;
            Model.Appointment appointment = new Model.Appointment { 
                Id =  _id,
                Date = _date };
            appointmentHandler.Create(appointment);
            doctorWindow.BackToDoctorWindow();
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            doctorWindow.BackToDoctorWindow();
        }
    }
}