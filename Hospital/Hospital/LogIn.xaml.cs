using System.Windows;
using System.Windows.Media;
using Hospital.Controller;
using Hospital.Repository;
using Hospital.Service;
using Hospital.View.DoctorView;
using Hospital.View.ManagerView;
using Hospital.View.PatientView;
using Hospital.View.SecretaryView;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private App _app;
        private string _username;
        private string _password;
        private readonly object _content;

        public LogIn()
        {
            _app = Application.Current as App;
            InitializeComponent();
            _content = Content;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            _username = username.Text;
            _password = password.Password.ToString();
            (bool isValid, string type) = _app._userController.IsLogInValid(_username, _password);
            if (isValid == false)
            {
                username.Background = Brushes.Red;
                password.Background = Brushes.Red;
            }
            else
            {
                if (type.Equals("doctor"))
                {
                    MainPage mainPage = new MainPage();
                    mainPage.Show();
                    Close();
                }
                else if (type.Equals("manager"))
                {
                    ManagerHomeWindow managerHomeWindow = new ManagerHomeWindow();
                    managerHomeWindow.Show();
                    Close();
                }
                else if (type.Equals("patient"))
                {
                    PatientWindow patientWindow = new PatientWindow();
                    patientWindow.Show();
                    Close();
                }
                else if (type.Equals("secretary"))
                {
                    SecretaryWindow secretaryWindow = new SecretaryWindow();
                    secretaryWindow.Show();
                    Close();
                }
            }

            
        }
        public void BackToLogInWindow()
        {
            Content = _content;
        }
    }
}
