using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Model;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace Hospital.View.DoctorView.Requests
{
    public partial class VacationPage
    {
        private App _app;
        public VacationPage()
        {
            InitializeComponent();
            _app = Application.Current as App;
            DataContext = this;
            VacationDataGrid.ItemsSource = _app?._vacationController.Read();
        }

        private void NewRequest_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new CreateRequestPage());
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }
    }
}