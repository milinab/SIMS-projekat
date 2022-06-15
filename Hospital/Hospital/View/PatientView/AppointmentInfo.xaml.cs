using Hospital.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for AppointmentInfo.xaml
    /// </summary>
    public partial class AppointmentInfo : Page
    {
        private App app;
        private readonly object _content;
        private PatientWindow _patientWindow;
        private Appointment _appointment;
        public Patient patient;

        public AppointmentInfo(PatientWindow patientWindow, Appointment appointment)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            _appointment = appointment;
            this.DataContext = this;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            InitializeData();
        }

        private void InitializeData()
        {
            Doctor doctor = app._doctorController.ReadById(this._appointment.DoctorId);
            Anamnesis anamnesis = app._anamnesisController.ReadByAppointmentId(this._appointment.Id);
            this.appDoctor.Text = doctor.Name;
            this.appDate.Text = _appointment.Date.ToString("d.M.yyyy");
            if (anamnesis != null)
            {
                this.diagnosis.Text = anamnesis.Diagnosis;
                this.prescribedMedicine.Text = anamnesis.Therapy.Medicine;
                this.therapy.Text = anamnesis.Therapy.TherapyText;
            }
            
        }

        private void PastAppointments_Click(object sender, RoutedEventArgs e)
        {
            Page pastAppointmentsPage = new PastAppointments();
            PatientWindow.getInstance().frame.Navigate(pastAppointmentsPage);

        }
       
    }
}
