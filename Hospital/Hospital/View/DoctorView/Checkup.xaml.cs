using System.Windows;
using System.Windows.Controls;
using Hospital.View.DoctorView.Appointments;

namespace Hospital.View.DoctorView
{
    public partial class Checkup : Page
    {
        private Frame _frame;
        
        public Checkup(Frame frame)
        {
            _frame = frame;
            InitializeComponent();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Checkup(_frame));
        }

        private void ScheduleAppointmentButton(object sender, RoutedEventArgs e)
        {
            Add addPage = new Add(_frame);
            _frame.Navigate(addPage);
        }
    }
}