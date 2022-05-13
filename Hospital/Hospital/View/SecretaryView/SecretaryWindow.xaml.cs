using System.Windows;
using Hospital.Controller;
using Hospital.Model;


namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for SecretaryWindow.xaml
    /// </summary>
    public partial class SecretaryWindow : Window
    {

        private App app;
        private readonly object _content;


        public SecretaryWindow()
        {
            app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _content = Content;

            dataGridPatients.ItemsSource = app._patientController.Read();

        }

        private void DeletePatient(object sender, RoutedEventArgs e)
        {
            Patient patient = dataGridPatients.SelectedValue as Patient;
            app._userController.Delete(app._userController.FindId(patient.Username));
            app._medicalRecordController.Delete(patient.MedicalRecordId);
            app._patientController.Delete(patient.Id);
        }

        public void AddPatientClick(object sender, RoutedEventArgs e)
        {
            var addPatientWindow = new AddPatient(this);
            Content = addPatientWindow;
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {

            Patient patient = dataGridPatients.SelectedValue as Patient;
            int userId = app._userController.FindId(patient.Username);
            if (patient.AccountType == "patient")
            {
                var editPatientWindow = new EditPatient(patient, userId, this);
                Content = editPatientWindow;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Content = _content;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AppointmentPage appointmentPage = new AppointmentPage();
            appointmentPage.Show();
            this.Close();
        }

        public void BackToSecretaryWindow()
        {
            Content = _content;
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

        private void dataGridPatients_SelectionChanged()
        {

        }
    }
}
