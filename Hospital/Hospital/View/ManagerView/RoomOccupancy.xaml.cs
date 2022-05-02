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
using System.Windows.Shapes;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for RoomOccupancy.xaml
    /// </summary>
    public partial class RoomOccupancy : Window
    {
        private readonly object _content;
        private readonly AppointmentController _appointmentController;


        public RoomOccupancy(AppointmentController appointmentController)
        {
            InitializeComponent();
            _content = Content;
            this.DataContext = this;
            _appointmentController = appointmentController;
            gridAppointment.ItemsSource = _appointmentController.Read();
        }

        private void RenovateClick(object sender, RoutedEventArgs e)
        {
            Renovate renovate = new Renovate(this, _appointmentController);
      
                Content = renovate;
            
        }

        public void BackToRoomOccupancy()
        {
            Content = _content;
        }

    }
}
