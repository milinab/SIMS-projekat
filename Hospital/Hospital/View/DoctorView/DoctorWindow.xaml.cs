using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.View.DoctorView {
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow {

        private readonly object _content;
        private readonly AppointmentController _appointmentController;
        public DoctorWindow(AppointmentController controller) {
            InitializeComponent();
            _content = Content;
            this.DataContext = this;
            _appointmentController = controller;
            gridAppointments.ItemsSource = _appointmentController.Read();

        }
        private void AddClick(object sender, RoutedEventArgs e) {
            
            Add addPage = new Add(this, _appointmentController);
            Content = addPage;
        }
        private void EditClick(object sender, RoutedEventArgs e) {
            if (gridAppointments.SelectedItem != null) {
                Edit editWindow = new Edit((Appointment)gridAppointments.SelectedItem, _appointmentController);
                editWindow.Show();
            }
            else {
                MessageBox.Show("You must select a row first", "Warning");
            }
        }
        private void DeleteClick(object sender, RoutedEventArgs e) {
            if (gridAppointments.SelectedItem != null) {
                Appointment app = (Appointment)gridAppointments.SelectedItem;
                _appointmentController.Delete(app.Id);
            } else {
                MessageBox.Show("You must select a row first", "Warning");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        public void BackToDoctorWindow() {
            Content = _content;
        }
    }
}
