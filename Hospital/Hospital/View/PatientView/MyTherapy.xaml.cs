using Hospital.Model;
using System.Windows;
using System.Windows.Controls;
using Hospital.View.PatientView.ViewModel;
using Syncfusion.UI.Xaml.Scheduler;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for MyTherapy.xaml
    /// </summary>
    public partial class MyTherapy : Page
    {
        public Patient patient;
        MyTherapyViewModel mtvm;
        public MyTherapy(PatientWindow patientWindow)
        {
            mtvm = new MyTherapyViewModel();
            InitializeComponent();
            this.DataContext = mtvm;
        }

        private void TherapyCalendar_OnAppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// Disables Appointment dragging
        /// </summary>
        private void TherapyCalendar_OnAppointmentDragStarting(object sender, AppointmentDragStartingEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// Disables Appointment resizing
        /// </summary>
        private void TherapyCalendar_OnAppointmentResizing(object sender, AppointmentResizingEventArgs e)
        {
            e.CanContinueResize = false;
        }

    }
}
