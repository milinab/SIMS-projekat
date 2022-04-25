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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.Doctor;
using Hospital.Model;

namespace Hospital {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
            .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        
        private string _appointmentsPath = _projectPath + System.IO.Path.DirectorySeparatorChar + "Resources"
            + System.IO.Path.DirectorySeparatorChar + "Data" + System.IO.Path.DirectorySeparatorChar +"appointments.csv"; 

        public AppointmentController AppointmentController { get; set; }

        public MainWindow() {
            InitializeComponent();

            AppointmentRepository appointmentRepository = new AppointmentRepository(_appointmentsPath);
            AppointmentService appointmentService = new AppointmentService(appointmentRepository);
            AppointmentController = new AppointmentController(appointmentService);
        }
        private void DoctorClick(object sender, RoutedEventArgs e) {
            DoctorWindow doctorWindow = new DoctorWindow(AppointmentController);
            doctorWindow.Show();
            Close();
        }
        private void ManagerClick(object sender, RoutedEventArgs e) {
            Manager.ManagerWindow managerWindow = new Manager.ManagerWindow();
            managerWindow.Show();
            Close();
        }
        private void SecretaryClick(object sender, RoutedEventArgs e) {
            Secretary.SecretaryWindow secretaryWindow = new Secretary.SecretaryWindow();
            secretaryWindow.Show();
            Close();
        }
        private void PatientClick(object sender, RoutedEventArgs e) {
            PatientUI.PatientWindow patientWindow = new PatientUI.PatientWindow();
            patientWindow.Show();
            Close();
        }
    }
}
