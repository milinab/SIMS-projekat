using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;

namespace Hospital.View.DoctorView.Checkup
{
    public partial class ReferralPage : Page
    {
        private readonly Patient _patient;
        private App _app;
        public ReferralPage(Patient patient)
        {
            InitializeComponent();
            _patient = patient;
            _app = Application.Current as App;
            var specializations = new List<string>{"Cardiology", "General practice"};
            SpecializationListView.ItemsSource = specializations;
        }

        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            if (SpecializationListView.SelectedItem == null || SpecialistListView.SelectedItem == null || ReasonTextBox.Text.Length == 0)
            {
                return;
            }
            var fullName = SpecialistListView.SelectedItem.ToString();
            var parts = fullName.Split(' ');
            var doctors = _app._doctorController.Read();
            var specialistIds = doctors.Where(doctor => doctor.Name.Equals(parts[0]) && 
                                            doctor.LastName.Equals(parts[1])).Select(doctor => doctor.Id).ToList();
            var specialistId = specialistIds.Count == 1 ? specialistIds.FirstOrDefault() : 0;
            var referral = new Referral(_patient.Id, SpecializationListView.SelectedItem.ToString(), 
                specialistId, ReasonTextBox.Text);
            _app._referralController.Create(referral);
            MainWindow.MainFrame.GoBack();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }

        private void SpecializationListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var doctors = _app._doctorController.Read();
            var specialists = doctors.Where(
                doctor => SpecializationListView.SelectedItem.ToString().Equals(doctor.Specialization)).Select(
                specialist => specialist.Name + " " + specialist.LastName).ToList();
            SpecialistListView.ItemsSource = specialists.Count > 0 ? specialists : null;
        }
    }
}