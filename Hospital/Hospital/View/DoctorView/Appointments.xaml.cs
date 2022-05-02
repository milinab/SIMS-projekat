using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.View.DoctorView {
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class Appointments
    {

        private App _app;
        private readonly object _content;
        private readonly LogIn _logIn;
        public Appointments(LogIn logIn)
        {
            _app = Application.Current as App;
            InitializeComponent();
            LiveDateTimeLabel.Content = DateTime.Now.ToString("ddd, d.M.yyyy.\nH:mm");
            _logIn = logIn;
            _content = Content;
            DataContext = this;
            GridAppointments.ItemsSource = _app._appointmentController.Read();
            DispatcherTimer liveDateTime = new DispatcherTimer();
            liveDateTime.Interval = TimeSpan.FromSeconds(1);
            liveDateTime.Tick += TimerTick;
            liveDateTime.Start();
        }
        private void AddClick(object sender, RoutedEventArgs e) {
            
            Add addPage = new Add(this);
            _logIn.Content = addPage;
        }
        private void EditClick(object sender, RoutedEventArgs e) {
            if (GridAppointments.SelectedItem != null) {
                Edit editWindow = new Edit((Appointment)GridAppointments.SelectedItem);
                editWindow.Show();
            }
            else {
                MessageBox.Show("You must select a row first", "Warning");
            }
        }
        private void DeleteClick(object sender, RoutedEventArgs e) {
            if (GridAppointments.SelectedItem != null) {
                Appointment appointment = (Appointment)GridAppointments.SelectedItem;
                _app._appointmentController.Delete(appointment.Id);
            } else {
                MessageBox.Show("You must select a row first", "Warning");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        public void SwitchPage() {
            _logIn.Content = _content;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            LiveDateTimeLabel.Content = DateTime.Now.ToString("ddd, d.M.yyyy.\nH:mm");
        }
    }
}
