using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Hospital.Controller;
using Hospital.Model;
using Hospital.View.DoctorView.Appointments;

namespace Hospital.View.DoctorView {
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class MainPage
    {

        private App _app;
        public MainPage()
        {
            _app = Application.Current as App;
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        public void SwitchPage()
        {
            Frame.Navigate(new AppointmentsPage(Frame));
        }

        private void CheckupPage(object sender, RoutedEventArgs e)
        {

        }

        private void AppointmentsPage(object sender, RoutedEventArgs e)
        {
            Frame.Content = new AppointmentsPage(Frame);
        }

        private void PatientsPage(object sender, RoutedEventArgs e)
        {

        }

        private void RequestsPage(object sender, RoutedEventArgs e)
        {

        }

        private void MalfunctionReportPage(object sender, RoutedEventArgs e)
        {

        }

        private void AccountPage(object sender, RoutedEventArgs e)
        {

        }

        private void LogOutPage(object sender, RoutedEventArgs e)
        {
            new LogIn().Show();
            Close();
        }

        
    }
}
