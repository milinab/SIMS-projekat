using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Model;

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
            ErrorTextBlock.Text = "";
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
                        ErrorTextBlock.Text = "You already have a pending request";
                        return;
                    }
                    ErrorTextBlock.Text = "Wrong date";
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
                        ErrorTextBlock.Text = "You already have a pending request";
                        return;
                    }
                    if (exception.Message.Equals("SpecializationException"))
                    {
                        ErrorTextBlock.Text = "Doctor with this specialization has already requested vacation";
                        return;
                    }
                    ErrorTextBlock.Text = "Wrong date" ;
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