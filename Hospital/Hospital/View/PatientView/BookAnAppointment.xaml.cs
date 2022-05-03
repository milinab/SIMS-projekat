﻿using System;
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
using Hospital.Controller;
using Hospital.Model;
using System.Collections.ObjectModel;


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
        private readonly AppointmentController _appointmentController;
        private readonly UserController _userController;
        private readonly DoctorController _doctorController;

        public ObservableCollection<Doctor> Doctors
        {
            get;
            set;
        }

        public BookAnAppointment(PatientWindow patientWindow, AppointmentController appointmentController, UserController userController)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            dataGridAppointments.ItemsSource = patientWindow.dataGridAppointments.ItemsSource;
            //dataGridAppointments.ItemsSource = app._appointmentController.Read();
            _patientWindow = patientWindow;
            _appointmentController = appointmentController;
            _userController = userController;
            Doctors = new ObservableCollection<Doctor>();
            Doctors = app._doctorController.Read();
            doctorsComboBox.ItemsSource = Doctors;

        }



        public BookAnAppointment(UserController userController)
        {
            _userController = userController;
        }

        private bool validate()
        {
         

            if(DoctorPriority.IsChecked == false && DatePriority.IsChecked == false)
            {
                MessageBox.Show("You need to select a priority.", "Warning");
                return false;
            }
            return false;
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {

            //if (!validate())
            //{
            //    return;
            //}

            //if (DoctorPriority.IsChecked == true)
            //{
            //DoctorPriorityDateAvailable DoctorPriorityDateAvailablePage = new DoctorPriorityDateAvailable(_patientWindow ,this,app._appointmentController);
            //Content = DoctorPriorityDateAvailablePage;
            //}
            // if (DatePriority.IsChecked == true)
            //{
            //BookAnAppointment bookAnAppointmentPage = new BookAnAppointment(this, app._appointmentController);
            //Content = bookAnAppointmentPage;

            // }
            
            //doctorsComboBox.ItemsSource = app._userController.ReadAll();

            int DoctorId = Int32.Parse(((Model.User)doctorsComboBox.SelectedItem).Id.ToString());
            
            DateTime _date = myCalendar.SelectedDate.Value;



            Appointment appointment = new Appointment
            {
                DoctorId = DoctorId,
                Date = _date
            };
            _appointmentController.Create(appointment);
            _patientWindow.BackToPatientWindow();
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
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