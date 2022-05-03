﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Hospital.Model;

namespace Hospital.View.DoctorView.Appointments
{
    /// <summary>
    /// Interaction logic for AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage : Page
    {
        private App _app;
        private Frame _frame;
        
        public AppointmentsPage(Frame frame)
        {
            _app = Application.Current as App;
            InitializeComponent();
            _frame = frame;
            LiveDateTimeLabel.Content = DateTime.Now.ToString("ddd, d.M.yyyy.\nH:mm");
            DataContext = this;
            GridAppointments.ItemsSource = _app._appointmentController.Read();
            DispatcherTimer liveDateTime = new DispatcherTimer();
            liveDateTime.Interval = TimeSpan.FromSeconds(1);
            liveDateTime.Tick += TimerTick;
            liveDateTime.Start();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {

            Add addPage = new Add(this);
            _frame.Navigate(addPage);
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (GridAppointments.SelectedItem != null)
            {
                Edit editPage = new Edit((Appointment)GridAppointments.SelectedItem, this);
                _frame.Navigate(editPage);
            }
            else
            {
                MessageBox.Show("You must select a row first", "Warning");
            }
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (GridAppointments.SelectedItem != null)
            {
                Appointment appointment = (Appointment)GridAppointments.SelectedItem;
                _app._appointmentController.Delete(appointment.Id);
            }
            else
            {
                MessageBox.Show("You must select a row first", "Warning");
            }
        }
        
        private void ViewClick(object sender, RoutedEventArgs e)
        {
            if (GridAppointments.SelectedItem != null)
            {
                ViewPatientInformations view = new ViewPatientInformations((Appointment)GridAppointments.SelectedItem, this);
                _frame.Navigate(view);
            }
            else
            {
                MessageBox.Show("You must select a row first", "Warning");
            }
        }
        
        public void SwitchPage() {
            _frame.Navigate(Content);
            GridAppointments.ItemsSource = _app._appointmentController.Read();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            LiveDateTimeLabel.Content = DateTime.Now.ToString("ddd, d.M.yyyy.\nH:mm");
        }
        
    }
}