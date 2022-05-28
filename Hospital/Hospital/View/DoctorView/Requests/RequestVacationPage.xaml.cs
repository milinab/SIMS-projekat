using System;
using System.Windows;
using System.Windows.Controls;
using Hospital.Enums;
using Hospital.Model;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace Hospital.View.DoctorView.Requests
{
    public partial class RequestVacationPage
    {
        private App _app;
        public RequestVacationPage()
        {
            _app = Application.Current as App;
            InitializeComponent();
            StartDate.SelectedDate = DateTime.Today.AddDays(2);
            StartDate.DisplayDateStart = DateTime.Today.AddDays(2);
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            if (UrgentCheckBox.IsChecked ?? false)
            {
                string specialization = null;
                if (StartDate.SelectedDate != null && EndDate.SelectedDate != null &&
                    !string.IsNullOrEmpty(ReasonTextBox.Text))
                {
                    foreach (var doctor in _app._doctorController.Read())
                    {
                        if (LogIn.LoggedUser.Id == doctor.Id)
                        {
                            specialization = doctor.Specialization;
                        }
                    }

                    Vacation vacation = new Vacation((DateTime)StartDate.SelectedDate, (DateTime)EndDate.SelectedDate,
                        ReasonTextBox.Text, specialization, VacationState.Awaiting);
                    if (!vacation.IsStartDateBeforeDate(DateTime.Today.AddDays(2)) &&
                        !vacation.IsEndDateBeforeDate((DateTime)StartDate.SelectedDate))
                    {
                        _app._vacationController.Create(vacation);
                        MainWindow.MainFrame.GoBack();
                        return;
                    }
                }

                MessageBox.Show("Greska");
            }

            else
            {
                try
                {
                    string specialization = null;
                    if (StartDate.SelectedDate != null && EndDate.SelectedDate != null &&
                        !string.IsNullOrEmpty(ReasonTextBox.Text))
                    {
                        foreach (var doctor in _app._doctorController.Read())
                        {
                            if (LogIn.LoggedUser.Id == doctor.Id)
                            {
                                specialization = doctor.Specialization;
                            }
                        }

                        Vacation vacation = new Vacation((DateTime)StartDate.SelectedDate, (DateTime)EndDate.SelectedDate,
                            ReasonTextBox.Text, specialization, VacationState.Awaiting);
                        if (!vacation.IsStartDateBeforeDate(DateTime.Today.AddDays(2)) &&
                            !vacation.IsEndDateBeforeDate((DateTime)StartDate.SelectedDate))
                        {
                            _app._vacationController.NoPriorityCreate(vacation);
                            return;
                        }
                    }

                    MessageBox.Show("Greska");
                    MainWindow.MainFrame.GoBack();
                }
                catch
                {
                    MessageBox.Show("Doctor with this specialization has already requested vacation");
                }
            }
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