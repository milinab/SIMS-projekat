using Hospital.Controller;
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


namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AppointmentPage : Window
    {

        private App app;
        private readonly object _content;



        public AppointmentPage()
        {
            app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            _content = Content;
            dataGridAppointments.ItemsSource = app._appointmentController.Read();

        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SecretaryWindow secretaryWindow = new SecretaryWindow();
            secretaryWindow.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Content = _content;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = dataGridAppointments.SelectedValue as Appointment;
            app._appointmentController.Delete(appointment.Id);
        }

        public void AddButtton_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment addWindow = new AddAppointment(this);
            addWindow.Show();
            this.Close();

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            Appointment appointment =dataGridAppointments.SelectedValue as Appointment;
            EditAppointment editWindow = new EditAppointment(appointment, this);
            editWindow.Show();
            this.Close();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }
}