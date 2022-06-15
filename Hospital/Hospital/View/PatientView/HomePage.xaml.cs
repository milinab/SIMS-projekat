﻿using Hospital.Model;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public Patient patient;
        public HomePage(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
        }
    }
}
