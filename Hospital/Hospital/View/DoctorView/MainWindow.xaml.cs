using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Hospital.View.DoctorView.Appointments;
using Hospital.View.DoctorView.Checkup;
using Hospital.View.DoctorView.Requests;

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

        public static Frame MainFrame { get; set; }
        public MainWindow()
        {
            _app = Application.Current as App;
            InitializeComponent();
            selectedButtonColor = new SolidColorBrush(Color.FromRgb(149, 216, 235));
            selectedButtonTextColor = new SolidColorBrush(Color.FromRgb(15, 90, 150));
            ButtonColor = new SolidColorBrush(Color.FromRgb(15, 90, 150));
            ButtonTextColor = new SolidColorBrush(Color.FromRgb(192, 228, 252));
            Frame.Content = new AppointmentsPage();
            SelectedButtonColors(AppointmentsButton);
            MainFrame = Frame;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        public void SwitchPage()
        {
            Frame.Navigate(new AppointmentsPage());
        }

        private void CheckupPage(object sender, RoutedEventArgs e)
        {
            ResetSelectedButtons();
            SelectedButtonColors(CheckupButton);
            Frame.Navigate(new CheckupPage());
        }

        private void AppointmentsPage(object sender, RoutedEventArgs e)
        {
            ResetSelectedButtons();
            SelectedButtonColors(AppointmentsButton);
            Frame.Navigate(new AppointmentsPage());
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
            Frame.Navigate(new RequestsPage());
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
