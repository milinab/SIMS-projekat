using System;
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

namespace Hospital.PatientUI
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
