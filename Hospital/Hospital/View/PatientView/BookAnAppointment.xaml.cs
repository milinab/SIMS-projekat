using System;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for BookAnAppointment.xaml
    /// </summary>
    public partial class BookAnAppointment : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public Patient patient;

        public ObservableCollection<Doctor> Doctors
        {
            get;
            set;
        }

        public BookAnAppointment(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments(patient.Id);
            _patientWindow = patientWindow;

            List<Doctor> doctorList = app._doctorController.Read();
            ObservableCollection<Doctor> Doctors = new ObservableCollection<Doctor>(doctorList);

            doctorsComboBox.ItemsSource = Doctors;
            myCalendar.DisplayDateStart = DateTime.Now.AddDays(1);
        }

        private bool Validate()
        {
         
            if(DoctorPriority.IsChecked == false && DatePriority.IsChecked == false)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a priority.");
                return false;
            }
            
            if(doctorsComboBox.SelectedItem==null)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a doctor");
                return false;
            }

            if(myCalendar.SelectedDate.HasValue==false)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a date");
                return false;
            }
            return true;
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                int DoctorId = Int32.Parse(((Model.User)doctorsComboBox.SelectedItem).Id.ToString());

                DateTime date = myCalendar.SelectedDate.Value;

                if (DoctorPriority.IsChecked == true)
                {
                    Page doctorPriority = new DoctorPriorityDateAvailable(DoctorId, date, this, _patientWindow);
                    PatientWindow.getInstance().frame.Navigate(doctorPriority);
                }
                if (DatePriority.IsChecked == true)
                {
                    Page datePriority = new DatePriority(DoctorId, date, this, _patientWindow);
                    PatientWindow.getInstance().frame.Navigate(datePriority);
                }
            }            
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }
        public void BackToBookAnAppointmentWindow()
        {
            Content = _content;
        }

    }
}
