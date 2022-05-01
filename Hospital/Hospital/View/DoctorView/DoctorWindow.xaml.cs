using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.View.DoctorView {
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow
    {

        private App app;
        private readonly object _content;
        public DoctorWindow()
        {
            app = Application.Current as App;
            InitializeComponent();
            _content = Content;
            this.DataContext = this;
            gridAppointments.ItemsSource = app._appointmentController.Read();

        }
        private void AddClick(object sender, RoutedEventArgs e) {
            
            Add addPage = new Add(this, app._appointmentController);
            Content = addPage;
        }
        private void EditClick(object sender, RoutedEventArgs e) {
            if (gridAppointments.SelectedItem != null) {
                Edit editWindow = new Edit((Appointment)gridAppointments.SelectedItem);
                editWindow.Show();
            }
            else {
                MessageBox.Show("You must select a row first", "Warning");
            }
        }
        private void DeleteClick(object sender, RoutedEventArgs e) {
            if (gridAppointments.SelectedItem != null) {
                Appointment appointment = (Appointment)gridAppointments.SelectedItem;
                app._appointmentController.Delete(appointment.Id);
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
