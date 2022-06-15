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
using Hospital.Model;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for RoomOccupancy.xaml
    /// </summary>
    public partial class RoomOccupancy : Window
    {
        private readonly object _content;
        private readonly RoomController _roomController;
        private readonly AppointmentController _appointmentController;
        private App _app;

        public RoomOccupancy(AppointmentController appointmentController, RoomController roomController)
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            refresh();
        }

        public void refresh()
        {
            gridAppointment.ItemsSource = _appointmentController.Read();
        }
        private void EquipmentClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.EquipmentWindow equipmentWindow = new View.ManagerView.EquipmentWindow(_app._equipmentController);
            equipmentWindow.Show();
            Close();
        }
        private void RoomClick(object sender, RoutedEventArgs e)
        {

            View.ManagerView.ManagerWindow roomWindow = new View.ManagerView.ManagerWindow(_app._roomController);
            roomWindow.Show();
            Close();
        }

        private void OccupancyClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.RoomOccupancy roomOccupancy = new View.ManagerView.RoomOccupancy(_app._appointmentController, _app._roomController);
            roomOccupancy.Show();
            Close();
        }
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.ManagerHomeWindow managerHomeWindow = new ManagerHomeWindow();
            managerHomeWindow.Show();
            Close();
        }
        private void MedicineClick(object sender, RoutedEventArgs e)
        {
            MedicineWindow medicine = new MedicineWindow(_app._medicineController);
            medicine.Show();
            Close();
        }
        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            Close();
        }
        private void MergeClick(object sender, RoutedEventArgs e)
        {
            MergeRooms mergeRooms = new MergeRooms(this, _roomController);
            Content = mergeRooms;
        }
        private void DivideClick(object sender, RoutedEventArgs e)
        {
            DivideRoom divideRoom = new DivideRoom(this, _roomController);
            Content = divideRoom;
        }
        private void SurveyClick(object sender, RoutedEventArgs e)
        {
            SurveySelect surveySelect = new SurveySelect();
            surveySelect.Show();
            Close();
        }
    }
}
