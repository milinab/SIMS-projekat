using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Hospital.Enums;
using Hospital.View.DoctorView.Account;
using Hospital.View.DoctorView.Appointments;
using Hospital.View.DoctorView.Checkup;
using Hospital.View.DoctorView.MalfunctionReport;
using Hospital.View.DoctorView.Patients;
using Hospital.View.DoctorView.Requests;

namespace Hospital.View.DoctorView {
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private App _app;
        private readonly SolidColorBrush _selectedButtonColor;
        private readonly SolidColorBrush _selectedButtonTextColor;
        private readonly SolidColorBrush _buttonColor;
        private readonly SolidColorBrush _buttonTextColor;

        public static Frame MainFrame { get; set; }
        public static Button MedicineButton { get; set; }
        public MainWindow()
        {
            FontFamily = new FontFamily("Roboto");
            _app = Application.Current as App;
            InitializeComponent();
            // ReSharper disable PossibleNullReferenceException
            var primaryColor = (Color)ColorConverter.ConvertFromString("#9FA8DA");
            var themeColor = (Color)ColorConverter.ConvertFromString("#121212");
            var white = (Color)ColorConverter.ConvertFromString("#FFFFFF");
            _selectedButtonColor = new SolidColorBrush(primaryColor);
            _selectedButtonTextColor = new SolidColorBrush(themeColor);
            _buttonColor = new SolidColorBrush(themeColor);
            _buttonTextColor = new SolidColorBrush(white);
            Frame.Content = new AppointmentsPage();
            SelectedButtonColors(AppointmentsButton);
            MainFrame = Frame;
            var medicines = _app._medicineController.Read();
            foreach (var medicine in medicines)
            {
                if (medicine.Status == MedicineStatus.Awaiting)
                {
                    VerifyMedicine.Visibility = Visibility.Visible;
                }
            }
            MedicineButton = VerifyMedicine;
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
            Frame.Navigate(new PatientsPage());
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
            Frame.Navigate(new MalfunctionReportPage());
        }

        private void AccountPage(object sender, RoutedEventArgs e)
        {
            ResetSelectedButtons();
            SelectedButtonColors(AccountButton);
            Frame.Navigate(new AccountPage());
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
            button.Background = _selectedButtonColor;
            button.Foreground = _selectedButtonTextColor;
        }
        
        private void ButtonColors(Button button)
        {
            button.Background = _buttonColor;
            button.Foreground = _buttonTextColor;
        }

        private void VerifyMedicine_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new VerifyMedicineUC());
        }
    }
}
