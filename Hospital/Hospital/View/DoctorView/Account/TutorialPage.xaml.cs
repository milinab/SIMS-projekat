using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.DoctorView.Account
{
    public partial class TutorialPage : Page
    {
        public TutorialPage()
        {
            InitializeComponent();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }
    }
}