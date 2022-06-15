using System.Windows;
using System.Windows.Controls;
using Hospital.Model;

namespace Hospital.View.DoctorView.Appointments
{
    public partial class PatientInformationPage : Page
    {
        
        public PatientInformationPage(Appointment app)
        {
            InitializeComponent();
            Patient patient = app.Patient;
            Name.Text = patient.Name;
            LastName.Text = patient.LastName;
            HealthInsuranceId.Text = patient.HealthInsuranceId;
            Gender.Text = patient.HealthInsuranceId;
            BloodType.Text = patient.BloodType;
            ChronicDiseasesItemsControl.ItemsSource = patient.MedicalRecord.ChronicalDiseases;
            AllergiesItemsControl.ItemsSource = patient.MedicalRecord.AllergenIds;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }
    }
}