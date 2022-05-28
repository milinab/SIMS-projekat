using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using Hospital.Model;
using Syncfusion.UI.Xaml.Scheduler;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace Hospital.View.DoctorView.Appointments
{
    /// <summary>
    /// Interaction logic for AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage
    {
        private readonly App _app;
        public ObservableCollection<Appointment> Appointments { get; set; }

        public AppointmentsPage()
        {
            _app = Application.Current as App;
            Appointments = _app?._appointmentController.Read();
            
            
            DispatcherTimer liveDateTime = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            liveDateTime.Tick += TimerTick;
            liveDateTime.Start();
            
            InitializeComponent();
            DataContext = this;
            LiveDateTimeLabel.Content = DateTime.Now.ToString("ddd, d.M.yyyy.\nH:mm");
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            // MainWindow.MainFrame.Navigate(new Add());
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            // if (AppointmentsCalendar .SelectedItem != null)
            // {
            //     Edit editPage = new Edit((Appointment)GridAppointments.SelectedItem, this);
            //     _frame.Navigate(editPage);
            // }
            // else
            // {
            //     MessageBox.Show("You must select a row first", "Warning");
            // }
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            // if (GridAppointments.SelectedItem != null)
            // {
            //     Appointment appointment = (Appointment)GridAppointments.SelectedItem;
            //     _app._appointmentController.Delete(appointment.Id);
            // }
            // else
            // {
            //     MessageBox.Show("You must select a row first", "Warning");
            // }
        }
        
        private void ViewClick(object sender, RoutedEventArgs e)
        {
            // if (GridAppointments.SelectedItem != null)
            // {
            //     ViewPatientInformations view = new ViewPatientInformations((Appointment)GridAppointments.SelectedItem, this);
            //     _frame.Navigate(view);
            // }
            // else
            // {
            //     MessageBox.Show("You must select a row first", "Warning");
            // }
        }
        
        public void SwitchPage() {
            MainWindow.MainFrame.Navigate(Content);
            AppointmentsCalendar.ItemsSource = _app._appointmentController.Read();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            LiveDateTimeLabel.Content = DateTime.Now.ToString("ddd, d.M.yyyy.\nH:mm");
        }

        private void AppointmentsCalendar_OnAppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;
            var date = e.DateTime;
            foreach (var app in Appointments)
            {
                if (app.Date == date)
                {
                    MainWindow.MainFrame.Navigate(new Edit(app));
                }
            }
        }
    }
}
