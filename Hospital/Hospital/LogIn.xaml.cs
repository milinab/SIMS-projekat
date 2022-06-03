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
        public static User LoggedUser;

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
            if (ValidateLogInInputs(username, password)) return;
            (bool isValid, string type) = _app._userController.IsLogInValid(username, password);
            if (!isValid)
            {
                InvalidFieldsLabel.Visibility = Visibility.Visible;
                return;
            }
            OpenTypeWindow(type, username);
            LoggedUser = _app._userController.GetLoggedUser(username, password);
        }

        private bool PatientCheck(Patient p)
        {
            if (!p.IsActive)
            {
                MessageBox.Show("Your account is banned. Please wait for secretary to make Your account active again.");
                return false;
            }
            
            return true;
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

        private void OpenTypeWindow(string type, string username)
        {
            if (GetRoleWindow(type, username) == null) return;
            Window roleWindow = GetRoleWindow(type, username);
            roleWindow.Show();
            Close();
        }

        private Window GetRoleWindow(string role, string username)
        {
            
            switch (role)
            {
                case "doctor":
                    return new MainWindow();
                case "manager":
                    return new ManagerHomeWindow();
                case "patient":
                    Patient p = _app._patientController.ReadByUsername(username);
                    if (PatientCheck(p))
                    {
                        PatientWindow patientWindow = new PatientWindow(p);
                        patientWindow.Show();
                        Close();
                        return null;
                    }
                    return null;
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
