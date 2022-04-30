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


        private readonly AppointmentController _appointmentController;
        private readonly SecretaryWindow _secretaryWindow;
        public AppointmentPage(SecretaryWindow secretaryWindow, AppointmentController appointmentController)
        {

            _secretaryWindow = secretaryWindow;
            _appointmentController = appointmentController;
            InitializeComponent();
            dataGridAppointments.ItemsSource = _appointmentController.Read();
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
    }
}
