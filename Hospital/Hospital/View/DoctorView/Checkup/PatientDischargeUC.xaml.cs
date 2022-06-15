using System.Windows;

namespace Hospital.View.DoctorView.Checkup
{
    public partial class PatientDischargeUC
    {
        public PatientDischargeUC()
        {
            InitializeComponent();
        }

        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }
    }
}