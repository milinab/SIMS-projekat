using System.Windows;
using System.Windows.Controls;
using Hospital.Model;

namespace Hospital.View.DoctorView.Appointments
{
    public partial class ViewPatientInformations : Page
    {
        private AppointmentsPage _appointmentsPage;
        
        public ViewPatientInformations(Appointment app, AppointmentsPage appointmentsPage)
        {
            InitializeComponent();
            _appointmentsPage = appointmentsPage;
            Patient patient = app.Patient;
            Name.Text = patient.Name;
            LastName.Text = patient.LastName;
            HealthInsuranceId.Text = patient.HealthInsuranceId;
            Gender.Text = patient.HealthInsuranceId;
            BloodType.Text = patient.BloodType;
            // ChronicalDiseases.Items = patient.MedicalRecord.ChronicalDiseases;
            // Allergies.Items = patient.MedicalRecord.Allergies;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            _appointmentsPage.SwitchPage();
        }
    }
}