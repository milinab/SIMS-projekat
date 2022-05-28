using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using Hospital.View.DoctorView.Appointments;
using ServiceStack;

namespace Hospital.View.DoctorView.Checkup
{
    public partial class CheckupPage
    {
        private ObservableCollection<Patient> Patients { get; set; }

        public CheckupPage()
        {
            var app = Application.Current as App;
            Patients = app?._patientController.Read();
            InitializeComponent();
            DataContext = this;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new CheckupPage());
        }

        private void ScheduleAppointmentButton(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new Add((Patient)PatientListView.SelectedItem));
        }

        private void FullNameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<Patient> filtered;
            if (FullNameTextBox.Text.Split(null).Length == 1) 
            {
                var fullNamePart = FullNameTextBox.Text;
                filtered = Patients.Where(patient => patient.Name.ToLower().Contains(fullNamePart.ToLower()) 
                                                     || patient.LastName.ToLower().Contains(fullNamePart.ToLower()));
            }
            else if (FullNameTextBox.Text.Split(null).Length == 2)
            {
                var fullNameParts = FullNameTextBox.Text.Split(null);
                filtered = Patients.Where(patient => patient.Name.ToLower().Contains(fullNameParts[0].ToLower()) 
                                                     && patient.LastName.ToLower().Contains(fullNameParts[1].ToLower()));
            }
            else
            {
                filtered = null;
            }
            PatientListView.ItemsSource = filtered;     
            ClearListViewIfTextBoxIsEmpty(FullNameTextBox);    
        }

        private void HealthInsuranceIdTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var filtered = Patients.Where(patient => patient.HealthInsuranceId.ToString().StartsWith(HealthInsuranceIdTextBox.Text));
            PatientListView.ItemsSource = filtered;
            ClearListViewIfTextBoxIsEmpty(HealthInsuranceIdTextBox);
        }

        private void ClearListViewIfTextBoxIsEmpty(TextBox textBox)
        {
            if (textBox.Text.IsEmpty())
            {
                PatientListView.ItemsSource = null;
                AreButtonsEnabled(false);
            }
        }

        private void AreButtonsEnabled(bool areEnabled)
        {
            AppointmentButton.IsEnabled = areEnabled;
            TherapyButton.IsEnabled = areEnabled;
            HospitalTreatmentButton.IsEnabled = areEnabled;
            ReferralButton.IsEnabled = areEnabled;
            DischargeButton.IsEnabled = areEnabled;
        }

        private void PatientListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AreButtonsEnabled(true);
        }

        private void TherapyButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new TherapyPage((Patient) PatientListView.SelectedItem));
        }
    }
}