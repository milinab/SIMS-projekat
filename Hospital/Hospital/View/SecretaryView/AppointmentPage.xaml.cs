using Hospital.Controller;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {


   
        private readonly SecretaryWindow _secretaryWindow;
        public AppointmentPage(SecretaryWindow secretaryWindow)
        {

            _secretaryWindow = secretaryWindow;
            InitializeComponent();
            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _secretaryWindow.BackToSecretaryWindow();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.UpdateLayout();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _secretaryWindow.Close();
        }
    }
}
