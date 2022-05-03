using System.Windows;
using Hospital.Controller;
using Hospital.Model;


namespace Hospital.View.SecretaryView {
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
            //Patient patient1 = new Patient()
            //{
            //    Name = "Pera",
            //    LastName = "Lazic",
            //    Username = "peropera",
            //    AccountType = "Patient",
            //    Password = "p123eropera",
            //    Gender = "Male",
            //    IdNumber = "1111111111111",
            //    Phone = "061111111",
            //    Email = "pera@pera.mejl",
            //    DateOfBirth = new DateTime(1999, 10, 10),
            //    HealthInsuranceId = "12312312asda",
            //    MedicalRecord = new MedicalRecord()
            //    {
            //        ChronicalDiseases = "Diabetes"
            //    },
            //    BloodType = "A+",
            //    Address = new Address()
            //    {
            //        City = new City()
            //        {
            //            Country = new Country()
            //            {
            //                Name = "Serbia"
            //            },
            //            Zip = "15300",
            //            Name = "Loznica"
            //        },
            //        Street = "Dusana Jovanovica",
            //        Number = "15"
            //    }
                

            //};
            //_patientController.Create(patient1);
            //Patient patient2 = new Patient()
            //{

            //    Name = "Nikolina",
            //    LastName = "Radicevic",
            //    Username = "radicanina",
            //    AccountType = "Patient",
            //    Password = "whocares",
            //    Gender = "Female",
            //    IdNumber = "22222222222",
            //    Phone = "0622222222",
            //    Email = "ninasilna@321.32",
            //    DateOfBirth = new DateTime(1951, 1, 1),
            //    HealthInsuranceId = "222bbb222bb",
            //    MedicalRecord = new MedicalRecord()
            //    {
            //        ChronicalDiseases = "None"
            //    },
            //    BloodType = "O-",
            //    Address = new Address()
            //    {
            //        City = new City()
            //        {
            //            Country = new Country()
            //            {
            //                Name = "Germany"
            //            },
            //            Zip = "12220",
            //            Name = "Minchen"
            //        },
            //        Street = "Nikole Tesle 3",
            //        Number = "1b"
            //    }
            //};
            //PatientHandler.Create(patient2);
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
            AppointmentPage appointmentPage= new AppointmentPage();
            appointmentPage.Show();
            this.Hide();
        }

        public void BackToSecretaryWindow()
        {
            Content = _content;
        }

         private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }
    }
}
