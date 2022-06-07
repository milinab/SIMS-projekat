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

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for DivideRoom.xaml
    /// </summary>
    public partial class DivideRoom : Page
    {

        private App _app;
        private RoomController _roomController;
        private readonly RoomOccupancy _roomOccupancy;
        public DivideRoom(RoomOccupancy roomOccupancy, RoomController roomController)
        {
            InitializeComponent();
            _app = Application.Current as App;
            _roomController = roomController;
            _roomOccupancy = roomOccupancy;
            ObservableCollection<Room> rooms = _app._roomController.Read();
            ObservableCollection<String> roomName = new ObservableCollection<string>();
            ObservableCollection<String> roomType = new ObservableCollection<string>();
            foreach (Room room in rooms)
            {
                roomName.Add(room.Name);
            }
            foreach (Room room in rooms)
            {
                roomType.Add(room.Type);
            }
            RoomComboBox.ItemsSource = roomName;
            TypeComboBox.ItemsSource= roomType.Distinct();
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            _roomOccupancy.BackToRoomOccupancy();
        }

        private void DivideClick(object sender, RoutedEventArgs e)
        {
            Room newRoom = new Room
            {
                Name = RoomName.Text,
                Floor = "1",
                Type = TypeComboBox.Text
            };
            _app._roomController.Create(newRoom);
            _roomOccupancy.BackToRoomOccupancy();

        }

        private void EquipmentClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.EquipmentWindow equipmentWindow = new View.ManagerView.EquipmentWindow(_app._equipmentController);
            equipmentWindow.Show();
        }
        private void RoomClick(object sender, RoutedEventArgs e)
        {

            View.ManagerView.ManagerWindow roomWindow = new View.ManagerView.ManagerWindow(_app._roomController);
            roomWindow.Show();
        }

        private void OccupancyClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.RoomOccupancy roomOccupancy = new View.ManagerView.RoomOccupancy(_app._appointmentController, _app._roomController);
            roomOccupancy.Show();
        }
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.ManagerHomeWindow managerHomeWindow = new ManagerHomeWindow();
            managerHomeWindow.Show();
        }
        private void MedicineClick(object sender, RoutedEventArgs e)
        {
            MedicineWindow medicine = new MedicineWindow(_app._medicineController);
            medicine.Show();
        }
        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
        }
        private void SurveyClick(object sender, RoutedEventArgs e)
        {
            SurveySelect surveySelect = new SurveySelect();
            surveySelect.Show();
        }
    }
}
