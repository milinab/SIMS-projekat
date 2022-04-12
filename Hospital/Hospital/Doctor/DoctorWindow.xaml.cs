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
            table.ItemsSource = _appointmentHandler.ReadAll();

            _appointmentHandler.Create(new Model.Appointment { Id = 30 });
        }
        private void AddClick(object sender, RoutedEventArgs e) {
            
            Add addPage = new Add(this, _appointmentHandler);
            Content = addPage;
        }
        private void EditClick(object sender, RoutedEventArgs e) {
            Edit editWindow = new Edit((Model.Appointment)table.SelectedItem, _appointmentHandler);
            editWindow.Show();
        }
        private void DeleteClick(object sender, RoutedEventArgs e) {
            Model.Appointment app = (Model.Appointment)table.SelectedItem;
            _appointmentHandler.Delete(app.Id);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        public void BackToDoctorWindow() {
            Content = _content;
        }
    }
}
