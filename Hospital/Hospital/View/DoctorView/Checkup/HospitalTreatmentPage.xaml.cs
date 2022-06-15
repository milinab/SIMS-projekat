using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.DoctorView.Checkup
{
    public partial class HospitalTreatmentPage : Page
    {
        public HospitalTreatmentPage()
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