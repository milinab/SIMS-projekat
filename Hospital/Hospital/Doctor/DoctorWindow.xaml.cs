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
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window {

        private object _content;
        private Model.AppointmentHandler _appointmentHandler;
        public DoctorWindow() {
            InitializeComponent();
            _appointmentHandler = new Model.AppointmentHandler();
            _content = Content;
            this.DataContext = this;
            gridAppointments.ItemsSource = _appointmentHandler.ReadAll();

        }
        private void AddClick(object sender, RoutedEventArgs e) {
            
            Add addPage = new Add(this, _appointmentHandler);
            Content = addPage;
        }
        private void EditClick(object sender, RoutedEventArgs e) {
            if (gridAppointments.SelectedItem != null) {
                Edit editWindow = new Edit((Model.Appointment)gridAppointments.SelectedItem, _appointmentHandler);
                editWindow.Show();
            }
            else {
                MessageBox.Show("You must select row first", "Warning");
            }
        }
        private void DeleteClick(object sender, RoutedEventArgs e) {
            if (gridAppointments.SelectedItem != null) {
                Model.Appointment app = (Model.Appointment)gridAppointments.SelectedItem;
                _appointmentHandler.Delete(app.Id);
            } else {
                MessageBox.Show("You must select row first", "Warning");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        public void BackToDoctorWindow() {
            Content = _content;
        }
    }
}
