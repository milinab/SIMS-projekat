using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using Hospital.Model;
using Hospital.View.DoctorView.Appointments;
using ServiceStack;
using Application = System.Windows.Application;
using TextBox = System.Windows.Controls.TextBox;

namespace Hospital.View.DoctorView.Checkup
{
    public partial class CheckupPage
    {
        private ObservableCollection<Patient> Patients { get; set; }
        public static bool Appointment { get; set; }

        public CheckupPage()
        {
            var app = Application.Current as App;
            var patients = app?._patientController.Read();
            if (patients != null) Patients = new ObservableCollection<Patient>(patients);
            InitializeComponent();
            DataContext = this;
            DispatcherTimer dispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(0.5)
            };
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!Appointment) return;
            FeedbackBorder.Visibility = Visibility.Visible;
            var color = (Color)ColorConverter.ConvertFromString("#42A5F5");
            var colorBrush = new SolidColorBrush(color);
            AppointmentButton.BorderThickness = new Thickness(0.5);
            AppointmentButton.BorderBrush = colorBrush;
            Wait(4000);
            Appointment = false;
            FeedbackBorder.Visibility = Visibility.Hidden;
            AppointmentButton.BorderThickness = new Thickness(0);
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new ReportUC((Patient) PatientListView.SelectedItem, DiagnosisTextBox.Text));
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
            if (!textBox.Text.IsEmpty()) return;
            PatientListView.ItemsSource = null;
            AreButtonsEnabled(false);
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

        private void ReferralButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new ReferralPage((Patient) PatientListView.SelectedItem));
        }
        
        private void DischargeButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new PatientDischargeUC());
        }

        private void HospitalTreatment_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new HospitalTreatmentPage());
        }
        
        private void Wait(int milliseconds)
        {
            var timer = new Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            timer.Interval = milliseconds;
            timer.Enabled  = true;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
            };

            while (timer.Enabled)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
    }
}