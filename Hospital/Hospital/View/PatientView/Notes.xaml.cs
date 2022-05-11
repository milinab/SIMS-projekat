using System;
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
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Page
    {
        private App app;
        private readonly object _content;
        private Note note;
        private readonly PatientWindow _patientWindow;

        public ObservableCollection<Note> NotesList
        {
            get;
            set;
        }

        public Notes(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            dataGridNotes.ItemsSource = app._noteController.Read();
        }

        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            Content = _content;
        }

        private void Notes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }

        public void BackToPatientWindow()
        {
            Content = _content;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }

        private void InfoButtonClick(object sender, RoutedEventArgs e)
        {
            //Appointment appointment = dataGridAppointments.SelectedValue as Appointment;
            //int appointmentId = app._appointmentController.ReadById(appointment.Id);
            //var editAnAppointmentPage = new EditAnAppointment(appointment, this);
            //Content = editAnAppointmentPage;
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            //Appointment appointment = dataGridAppointments.SelectedValue as Appointment;
            //int appointmentId = app._appointmentController.ReadById(appointment.Id);
            //var editAnAppointmentPage = new EditAnAppointment(appointment, this);
            //Content = editAnAppointmentPage;
        }

        private void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            //Appointment appointment = dataGridAppointments.SelectedValue as Appointment;
            //int appointmentId = app._appointmentController.ReadById(appointment.Id);
            //var editAnAppointmentPage = new EditAnAppointment(appointment, this);
            //Content = editAnAppointmentPage;
        }
    }
}
