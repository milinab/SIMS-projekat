using System.Windows;
using Syncfusion.UI.Xaml.Scheduler;

namespace Hospital.View.DoctorView.Appointments
{
    /// <summary>
    /// Interaction logic for AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage
    {
        public AppointmentsPage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Sets custom page for Appointment editing
        /// </summary>
        private void AppointmentsCalendar_OnAppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;
            var date = e.DateTime;
            var app = Application.Current as App;
            // ReSharper disable once PossibleNullReferenceException
            foreach (var appointment in app?._appointmentController.Read())
            {
                if (appointment.Date == date)
                {
                    MainWindow.MainFrame.Navigate(new Edit(appointment));
                }
            }
        }

        /// <summary>
        /// Disables Appointment dragging
        /// </summary>
        private void AppointmentsCalendar_OnAppointmentDragStarting(object sender, AppointmentDragStartingEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// Disables Appointment resizing
        /// </summary>
        private void AppointmentsCalendar_OnAppointmentResizing(object sender, AppointmentResizingEventArgs e)
        {
            e.CanContinueResize = false;
        }
    }
}
