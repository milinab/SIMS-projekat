using Hospital.Model;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    /// 

    public partial class PatientWindow
    {
        private App app;
        private readonly object _content;
        private Doctor doctor;

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

        public PatientWindow()
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            dataGridAppointments.ItemsSource = app._appointmentController.Read();

            Appointments = new ObservableCollection<Appointment>();
            Doctors = new ObservableCollection<Doctor>();
            Appointments = app._appointmentController.Read();


            foreach (var a in Appointments) {
                 doctor = app._doctorController.ReadById(a.DoctorId);
                Doctors.Add(doctor);
            }

            //dataGridAppointments.ItemsSource = Doctors;


            Console.WriteLine("tesct");


        }

        private void BookAnAppointmentClick(object sender, RoutedEventArgs e)
        {

            BookAnAppointment bookAnAppointmentPage = new BookAnAppointment(this, app._appointmentController, app._userController);
            Content = bookAnAppointmentPage;
            
        }

        private void EditAnAppointmentClick(object sender, RoutedEventArgs e)
        {
            if (dataGridAppointments.SelectedItem != null)
            {
                Appointment appointment = (Appointment)dataGridAppointments.SelectedItem;
                //editAnAppointment.Show();
            }
            else
            {
                MessageBox.Show("Select an appointment You want to edit.", "Warning");
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Appointment appointment = dataGridAppointments.SelectedValue as Appointment;
            //int appointmentId = app._appointmentController.ReadById(appointment.Id);
            //var editAppointmentWindow = new EditAppointment(appointment, appointmentId, this);
            //Content = EditAnAppointment;
        }

        private void CancelAnAppointmentClick(object sender, RoutedEventArgs e)
        {
            if(dataGridAppointments.SelectedItem != null)
            {
                Appointment appointment = (Appointment)dataGridAppointments.SelectedItem;
                app._appointmentController.Delete(appointment.Id);
            } else
            {
                MessageBox.Show("Select an appointment You want to cancel.", "Warning");
            }
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            Content = _content;
        }

        public void BackToPatientWindow()
        {
            Content = _content;
        }

        private void OpenBookAnAppointmentWindowClick(object sender, RoutedEventArgs e)
        {

        }
    }
}