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
        private string _username;
        private string _password;
        private readonly AppointmentController _appointmentController;
        private readonly UserController _userController;
        private readonly PatientController _patientController;

        public LogIn()
        {
            InitializeComponent();

            UserRepository userRepository = new UserRepository();
            UserService userService = new UserService(userRepository);
            _userController = new UserController(userService);

            AppointmentRepository appointmentRepository = new AppointmentRepository();
            AppointmentService appointmentService = new AppointmentService(appointmentRepository);
            _appointmentController = new AppointmentController(appointmentService);

            PatientRepository patientRepository = new PatientRepository();
            PatientService patientService = new PatientService(patientRepository);
            _patientController = new PatientController(patientService);
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            _username = username.Text;
            _password = password.Password.ToString();
            (bool isValid, string type) = _userController.IsLogInValid(_username, _password);
            if (isValid == false)
            {
                username.Background = Brushes.Red;
                password.Background = Brushes.Red;
            }
            else
            {
                if (type.Equals("doctor"))
                {
                    DoctorWindow doctorWindow = new DoctorWindow(_appointmentController);
                    doctorWindow.Show();
                    Close();
                }
                else if (type.Equals("manager"))
                {
                    ManagerWindow managerWindow = new ManagerWindow();
                    managerWindow.Show();
                    Close();
                }
                else if (type.Equals("Patient"))
                {
                    PatientWindow patientWindow = new PatientWindow();
                    patientWindow.Show();
                    Close();
                }
                else if (type.Equals("secretary"))
                {
                    SecretaryWindow secretaryWindow = new SecretaryWindow(_patientController);
                    secretaryWindow.Show();
                    Close();
                }
            }
        }
    }
}
