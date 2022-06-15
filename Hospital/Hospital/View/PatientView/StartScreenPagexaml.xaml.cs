using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for StartScreenPagexaml.xaml
    /// </summary>
    public partial class StartScreenPagexaml : Page
    {
        private App app;
        private Doctor doctor;
        public Patient patient;
        public PatientWindow _patientWindow;

        public ObservableCollection<Appointment> Appointments
        {
            get;
            set;
        }

        public ObservableCollection<Doctor> Doctors
        {
            get;
            set;
        }

        public StartScreenPagexaml(PatientWindow patientWindow)
        {
            InitializeComponent();
            this._patientWindow = patientWindow;
            dataInitialize();
        }

        public void dataInitialize()
        {
            app = Application.Current as App;

            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments(patient.Id);

            List<Appointment> appointmentList = app._appointmentController.ReadFutureAppointments(patient.Id);
            Appointments = new ObservableCollection<Appointment>(appointmentList);
            
            Doctors = new ObservableCollection<Doctor>();

            foreach (var a in Appointments)
            {
                doctor = app._doctorController.ReadById(a.DoctorId);
                Doctors.Add(doctor);
            }
            this.DataContext = this;
        }



        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Appointment appointment = dataGridAppointments.SelectedValue as Appointment;
            var editAnAppointmentPage = new EditAnAppointment(appointment, PatientWindow.getInstance());
            PatientWindow.getInstance().frame.Content = editAnAppointmentPage;
        }

        private void CancelAnAppointmentClick(object sender, RoutedEventArgs e)
        {
            if (dataGridAppointments.SelectedItem != null)
            {
                Appointment appointment = (Appointment)dataGridAppointments.SelectedItem;
                app._appointmentController.Delete(appointment.Id);

                TrollSystem ts = new TrollSystem(_patientWindow, app);
                ts.Troll();
                PatientWindow.getInstance().BackToPatientWindow();
            }
            else
            {
                PopupNotification.SendPopupNotification("Warning", "Please, select an appointment You want to cancel.");
            }
        }

        private void BookAnAppointmentClick(object sender, RoutedEventArgs e)
        {

            PatientWindow.getInstance().frame.Content = new BookAnAppointment(PatientWindow.getInstance());

        }
    }


}
