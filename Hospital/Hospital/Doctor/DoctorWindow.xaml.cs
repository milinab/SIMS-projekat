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
using System.Windows.Shapes;
using Hospital.Model;

namespace Hospital.Doctor {
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window {

        private object _content;
        private readonly AppointmentController _controller;
        public DoctorWindow(AppointmentController controller) {
            InitializeComponent();
            _content = Content;
            this.DataContext = this;
            _controller = controller;
            gridAppointments.ItemsSource = _controller.ReadAll();

        }
        private void AddClick(object sender, RoutedEventArgs e) {
            
            Add addPage = new Add(this, _controller);
            Content = addPage;
        }
        private void EditClick(object sender, RoutedEventArgs e) {
            if (gridAppointments.SelectedItem != null) {
                Edit editWindow = new Edit((Appointment)gridAppointments.SelectedItem, _controller);
                editWindow.Show();
            }
            else {
                MessageBox.Show("You must select row first", "Warning");
            }
        }
        private void DeleteClick(object sender, RoutedEventArgs e) {
            if (gridAppointments.SelectedItem != null) {
                Appointment app = (Appointment)gridAppointments.SelectedItem;
                _controller.Delete(app.Id);
            } else {
                MessageBox.Show("You must select row first", "Warning");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        public void BackToDoctorWindow() {
            Content = _content;
        }
    }
}