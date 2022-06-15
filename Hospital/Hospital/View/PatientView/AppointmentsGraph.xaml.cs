using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for AppointmentsGraph.xaml
    /// </summary>
    public partial class AppointmentsGraph : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public Patient patient;
        public AppointmentsGraph(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            List<Appointment> appointmentsList = app._appointmentController.ReadAllAppointments(patient.Id);
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>(appointmentsList);

            int twoMonthsAgo = 0;
            int oneMonthAgo = 0;
            int thisMonth = 0;
            int nextMonth = 0;
            double avg;

            foreach (Appointment appointmentItem in appointments)
            {
                
                if (appointmentItem.Date > DateTime.Now.AddDays(-60) && appointmentItem.Date < DateTime.Now.AddDays(-30))
                    twoMonthsAgo++;
                if (appointmentItem.Date > DateTime.Now.AddDays(-30) && appointmentItem.Date < DateTime.Now)
                    oneMonthAgo++;
                if (appointmentItem.Date > DateTime.Now &&  appointmentItem.Date < DateTime.Now.AddDays(30))
                    thisMonth++;
                if (appointmentItem.Date > DateTime.Now.AddDays(30) && appointmentItem.Date < DateTime.Now.AddDays(60))
                    nextMonth++;
            }
            avg = appointmentsList.Count / 4;

            this.twoMonthsAgo.Text = twoMonthsAgo.ToString();
            this.oneMonthAgo.Text = oneMonthAgo.ToString();
            this.thisMonth.Text = thisMonth.ToString();
            this.nextMonth.Text = nextMonth.ToString();
            this.averageAppointments.Text = avg.ToString("n2");

            appointmentsGraph.Series[0].Points.Add(twoMonthsAgo).AxisLabel = "Two months ago";
            appointmentsGraph.Series[0].Points.Add(oneMonthAgo).AxisLabel = "One month ago";
            appointmentsGraph.Series[0].Points.Add(thisMonth).AxisLabel = "This month";
            appointmentsGraph.Series[0].Points.Add(nextMonth).AxisLabel = "Next month";
        }

        

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Page profilePage = new Profile(_patientWindow);
            PatientWindow.getInstance().frame.Navigate(profilePage);
        }

    }
}
