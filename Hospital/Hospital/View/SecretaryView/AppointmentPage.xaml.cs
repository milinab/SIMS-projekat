using Hospital.Controller;
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

namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AppointmentPage : Window
    {

        private App app;
        private readonly object _content;


        public AppointmentPage()
        {
            app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _content = Content;

            dataGridAppointments.ItemsSource = app._appointmentController.Read();
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

       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SecretaryWindow secretaryWindow = new SecretaryWindow();
            secretaryWindow.Show();
            this.Hide();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
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
