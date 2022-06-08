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
    public partial class CreateRequestPage
    {
        private App _app;
        public CreateRequestPage()
        {
            _app = Application.Current as App;
            InitializeComponent();
            StartDate.SelectedDate = DateTime.Today.AddDays(2);
            StartDate.DisplayDateStart = DateTime.Today.AddDays(2);
        }

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        private void Confirm(object sender, RoutedEventArgs e)
        {
            
            if (UrgentCheckBox.IsChecked ?? false)
            {
                if (!ValidateInput()) return;
                var doctor = _app._doctorController.ReadById(LogIn.LoggedUser.Id);
                var vacation = new Vacation((DateTime)StartDate.SelectedDate, (DateTime)EndDate.SelectedDate,
                    ReasonTextBox.Text, doctor, VacationState.Awaiting);
                try
                {
                    _app._vacationController.Create(vacation);
                    MainWindow.MainFrame.GoBack();
                }
                catch (VacationException exception)
                {
                    if (exception.Message.Equals("DoctorException"))
                    {
                        MessageBox.Show("You already have a pending request");
                        return;
                    } 
                    MessageBox.Show("Wrong date");
                }
            }
            else
            {
                if (!ValidateInput()) return;
                var doctor = _app._doctorController.ReadById(LogIn.LoggedUser.Id);

                var vacation = new Vacation((DateTime)StartDate.SelectedDate, (DateTime)EndDate.SelectedDate,
                    ReasonTextBox.Text, doctor, VacationState.Awaiting);
                try
                {
                    _app._vacationController.NoPriorityCreate(vacation);
                    MainWindow.MainFrame.GoBack();
                }
                catch (VacationException exception)
                {
                    if (exception.Message.Equals("DoctorException"))
                    {
                        MessageBox.Show("You already have a pending request");
                        return;
                    }
                    if (exception.Message.Equals("SpecializationException"))
                    {
                        MessageBox.Show("Doctor with this specialization has already requested vacation");
                        return;
                    }
                    MessageBox.Show("Wrong date");
                }
            }
        }

        private bool ValidateInput()
        {
            return StartDate.SelectedDate != null && EndDate.SelectedDate != null && !string.IsNullOrEmpty(ReasonTextBox.Text);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }

        private void StartDate_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartDate.SelectedDate == null) return;
            var startDate = (DateTime) StartDate.SelectedDate;
            EndDate.DisplayDateStart = startDate.AddDays(1);
            EndDate.SelectedDate = startDate.AddDays(1);
        }
    }
}