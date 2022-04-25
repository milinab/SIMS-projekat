﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Hospital.Model;


namespace Hospital.Secretary {
    /// <summary>
    /// Interaction logic for SecretaryWindow.xaml
    /// </summary>
    public partial class SecretaryWindow : Window {
        


        private PatientService PatientHandler;

        public SecretaryWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            PatientHandler = new PatientService();
            dataGridPatients.ItemsSource = PatientHandler.ReadAll();
            Patient patient1 = new Patient()
            {
                Name = "Pera",
                LastName = "Lazic",
                Username = "peropera",
                AccountType = "Patient",
                Password = "p123eropera",
                Gender = "Male",
                IdNumber = "1111111111111",
                Phone = "061111111",
                Email = "pera@pera.mejl",
                DateOfBirth = new DateTime(1999, 10, 10),
                HealthInsuranceId = "12312312asda",
                medicalRecord = new MedicalRecord()
                {
                    ChronicalDiseases = "Diabetes"
                },
                BloodType = "A+",
                Address = new Address()
                {
                    city = new City()
                    {
                        country = new Country()
                        {
                            Name = "Serbia"
                        },
                        Zip = "15300",
                        Name = "Loznica"
                    },
                    Street = "Dusana Jovanovica",
                    Number = "15"
                }
                

            };
            PatientHandler.Create(patient1);
            Patient patient2 = new Patient()
            {

                Name = "Nikolina",
                LastName = "Radicevic",
                Username = "radicanina",
                AccountType = "Patient",
                Password = "whocares",
                Gender = "Female",
                IdNumber = "22222222222",
                Phone = "0622222222",
                Email = "ninasilna@321.32",
                DateOfBirth = new DateTime(1951, 1, 1),
                HealthInsuranceId = "222bbb222bb",
                medicalRecord = new MedicalRecord()
                {
                    ChronicalDiseases = "None"
                },
                BloodType = "O-",
                Address = new Address()
                {
                    city = new City()
                    {
                        country = new Country()
                        {
                            Name = "Germany"
                        },
                        Zip = "12220",
                        Name = "Minchen"
                    },
                    Street = "Nikole Tesle 3",
                    Number = "1b"
                }
            };
            PatientHandler.Create(patient2);
        }

        private void DeletePatient(object sender, RoutedEventArgs e)
        {
            Patient patient = dataGridPatients.SelectedValue as Patient;
            PatientHandler.Delete(patient);
        }

        public void AddPatientClick(object sender, RoutedEventArgs e)
        {
            var addPatientWindow = new AddPatient(this, PatientHandler);
            addPatientWindow.ShowDialog();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            
            Patient patient = dataGridPatients.SelectedValue as Patient;
            if (patient.AccountType == "Patient")
            {
                var editPatientWindow = new EditPatient(patient, this, PatientHandler);
                editPatientWindow.ShowDialog();
            }
        }
    }
}