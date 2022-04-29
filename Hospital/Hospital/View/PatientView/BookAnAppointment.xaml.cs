using System.Windows;
using Hospital.Model;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BookAnAppointment : Window
    {
        PatientWindow appointmentsWindow;


        public BookAnAppointment(PatientWindow aw)
        {
            InitializeComponent();
            this.appointmentsWindow = aw;
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e) {

            appointmentsWindow.Appointments.Add(new Appointment() { Id = 3, Doctor = new Model.Doctor(TextBoxDoctor.Text, ""), Date = calendar.DisplayDate });

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
