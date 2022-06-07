using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.DoctorView.Requests
{
    public partial class RequestsPage : Page
    {
        public RequestsPage()
        {
            InitializeComponent();
        }

        private void EquipmentProcurement_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void Vacation_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new VacationPage());
        }
    }
}
