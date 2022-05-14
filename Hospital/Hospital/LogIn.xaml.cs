using System.Windows;
using System.Windows.Media;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
using Hospital.View.DoctorView;
using Hospital.View.ManagerView;
using Hospital.View.PatientView;
using Hospital.View.SecretaryView;
using ServiceStack;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private App _app;
        private readonly object _content;

        public LogIn()
        {
            _app = Application.Current as App;
            InitializeComponent();
            _content = Content;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            EnterUsernameLabel.Visibility = Visibility.Hidden;
            EnterPasswordLabel.Visibility = Visibility.Hidden;
            InvalidFieldsLabel.Visibility = Visibility.Hidden;
            string username = UsernameBox.Text;
            string password = PasswordBox.Password.ToString();
            Patient p = _app._patientController.ReadByUsername(username);
            if (ValidateLogInInputs(username, password)) return;
            (bool isValid, string type) = _app._userController.IsLogInValid(username, password);
            if (!isValid)
            {
                InvalidFieldsLabel.Visibility = Visibility.Visible;
                return;
            }
            OpenTypeWindow(type, p);
        }

        private void PatientCheck(Patient p)
        {
            if (p.IsActive)
            {
                PatientWindow patientWindow = new PatientWindow(p);
                patientWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Your account is banned. Please wait for secretary to make Your account active again.");
            }
        }

        private bool ValidateLogInInputs(string username, string password)
        {
            if (username.IsEmpty())
            {
                EnterUsernameLabel.Visibility = Visibility.Visible;
                return true;
            }

            if (password.IsEmpty())
            {
                EnterPasswordLabel.Visibility = Visibility.Visible;
                return true;
            }
            return false;
        }

        private void OpenTypeWindow(string type, Patient p)
        {
            if (GetRoleWindow(type, p) == null) return;
            PatientCheck(p);
            Window roleWindow = GetRoleWindow(type, p);
            roleWindow.Show();
            Close();
        }

        private Window GetRoleWindow(string role, Patient p)
        {
            
            switch (role)
            {
                case "doctor":
                    return new MainWindow();
                case "manager":
                    return new ManagerHomeWindow();
                case "patient":
                    return new PatientWindow(p);
                case "secretary":
                    return new SecretaryWindow();
                default:
                    return null;
            }
        }

        public void BackToLogInWindow()
        {
            Content = _content;
        }
    }
}
