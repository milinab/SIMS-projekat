﻿using Hospital.Model;
using System;
using System.Windows;
using Hospital.Controller;
using System.Windows.Controls;

namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditPatient : Page
    {
        private int _id;
        private int _userId;
        private int _addressId;
        private int _medicalRecordId;
        private int _countryId;
        private int _cityId;
        private readonly SecretaryWindow _secretaryWindow;
        private readonly App _app;
        public EditPatient(Patient patient,int userId,SecretaryWindow secretaryWindow)
        {
            
            InitializeComponent();

            _app = Application.Current as App;
            _secretaryWindow = secretaryWindow;
            this.nameText.Text = patient.Name;
            this.lastNameText.Text = patient.LastName;
            this.usernameText.Text = patient.Username;
            this.passwordText.Text = patient.Password;
            this.genderText.Text = patient.Gender;
            this.idNumberText.Text = patient.IdNumber;
            this.phoneText.Text = patient.Phone;
            this.emailText.Text = patient.Email;
            this.datePicker.SelectedDate = patient.DateOfBirth;
            this.healthInsuranceIdText.Text = patient.HealthInsuranceId;
            this.bloodTypeText.Text = patient.BloodType;
            this.streetText.Text = patient.Address.Street;
            this.cityText.Text = patient.Address.City.Name;
            this.zipText.Text = patient.Address.City.Zip;
            this.chronicalDiseaseText.Text = patient.MedicalRecord.ChronicalDiseases;
            this.countryText.Text = patient.Address.City.Country.Name;
            this.numberText.Text = patient.Address.Number.ToString();
            _id = patient.Id;
            _userId = userId;
            _addressId = patient.AddressId;
            _medicalRecordId = patient.MedicalRecordId;
            _countryId = patient.Address.City.CountryId;
            _cityId = patient.Address.CityId;
            

        }
        private void CancelPatientOnClick(Object sender, RoutedEventArgs e)
        {
            _secretaryWindow.BackToSecretaryWindow();
        }

        private void EditPatientOnClick(Object sender, RoutedEventArgs e)
        {
            Country tempCountry = new Country(countryText.Text, _cityId);
            _app._countryController.Edit(tempCountry);
            City tempCity = new City(cityText.Text, zipText.Text, tempCountry, _countryId);
            _app._cityController.Edit(tempCity);
            Address tempAddress = _app._addressController.ReadById(_addressId);
            tempAddress = new Address(streetText.Text, numberText.Text, tempCity, _addressId);
            _app._addressController.Edit(tempAddress);
            User user = new User(nameText.Text, lastNameText.Text, idNumberText.Text, usernameText.Text,
                passwordText.Text, tempAddress, phoneText.Text, emailText.Text, "patient",
                (DateTime)datePicker.SelectedDate, _userId);
            _app._userController.Edit(user);
            MedicalRecord record = new MedicalRecord(chronicalDiseaseText.Text, _medicalRecordId);
            _app._medicalRecordController.Edit(record);
            Patient patient = new Patient(user, genderText.Text, bloodTypeText.Text, healthInsuranceIdText.Text, record, _id);
            
            _app._patientController.Edit(patient);
            _secretaryWindow.BackToSecretaryWindow();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _secretaryWindow.BackToSecretaryWindow();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AppointmentPage appointmentPage = new AppointmentPage(_secretaryWindow);
            Content = appointmentPage;
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _secretaryWindow.Close();
        }
    }
}
