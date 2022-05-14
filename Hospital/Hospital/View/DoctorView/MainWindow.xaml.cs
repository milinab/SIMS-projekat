using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Hospital.Controller;
using Hospital.Model;
using Hospital.View.DoctorView.Appointments;

namespace Hospital.View.DoctorView {
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private App _app;
        private SolidColorBrush selectedButtonColor;
        private SolidColorBrush selectedButtonTextColor;
        private SolidColorBrush ButtonColor;
        private SolidColorBrush ButtonTextColor;
        public MainWindow()
        {
            _app = Application.Current as App;
            InitializeComponent();
            selectedButtonColor = new SolidColorBrush(Color.FromRgb(149, 216, 235));
            selectedButtonTextColor = new SolidColorBrush(Color.FromRgb(15, 90, 150));
            ButtonColor = new SolidColorBrush(Color.FromRgb(15, 90, 150));
            ButtonTextColor = new SolidColorBrush(Color.FromRgb(192, 228, 252));
            Frame.Content = new AppointmentsPage(Frame);
            SelectedButtonColors(AppointmentsButton);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        public void SwitchPage()
        {
            Frame.Navigate(new AppointmentsPage(Frame));
        }

        private void CheckupPage(object sender, RoutedEventArgs e)
        {
            ResetSelectedButtons();
            SelectedButtonColors(CheckupButton);
            Frame.Navigate(new Checkup(Frame));
        }

        private void AppointmentsPage(object sender, RoutedEventArgs e)
        {
            ResetSelectedButtons();
            SelectedButtonColors(AppointmentsButton);
            Frame.Navigate(new AppointmentsPage(Frame));
        }

        private void PatientsPage(object sender, RoutedEventArgs e)
        {
            ResetSelectedButtons();
            SelectedButtonColors(PatientsButton);
        }

        private void RequestsPage(object sender, RoutedEventArgs e)
        {
            ResetSelectedButtons();
            SelectedButtonColors(RequestsButton);
        }

        private void MalfunctionReportPage(object sender, RoutedEventArgs e)
        {
            ResetSelectedButtons();
            SelectedButtonColors(MalfunctionReportButton);
        }

        private void AccountPage(object sender, RoutedEventArgs e)
        {
            ResetSelectedButtons();
            SelectedButtonColors(AccountButton);
        }

        private void LogOutPage(object sender, RoutedEventArgs e)
        {
            new LogIn().Show();
            Close();
        }

        private void ResetSelectedButtons()
        {
            ButtonColors(CheckupButton);
            ButtonColors(AppointmentsButton);
            ButtonColors(PatientsButton);
            ButtonColors(RequestsButton);
            ButtonColors(MalfunctionReportButton);
            ButtonColors(AccountButton);
        }

        private void SelectedButtonColors(Button button)
        {
            button.Background = selectedButtonColor;
            button.Foreground = selectedButtonTextColor;
        }
        
        private void ButtonColors(Button button)
        {
            button.Background = ButtonColor;
            button.Foreground = ButtonTextColor;
        }
    }
}
