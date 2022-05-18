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
    /// Interaction logic for MergeRooms.xaml
    /// </summary>
    public partial class MergeRooms : Page
    {

        private App _app;
        private readonly RoomController _roomController;
        private readonly RoomOccupancy _roomOccupancy;
        
        public MergeRooms(RoomOccupancy roomOccupancy, RoomController roomController)
        {
            InitializeComponent();
            _app = Application.Current as App;
            _roomController = roomController;
            _roomOccupancy = roomOccupancy;
            ObservableCollection<Room> rooms = _app._roomController.Read();
            ObservableCollection<String> roomName = new ObservableCollection<string>();
            foreach(Room room in rooms)
            {
                roomName.Add(room.Name);
            }
            disappearingRoomComboBox.ItemsSource = roomName;
            expandingRoomComboBox.ItemsSource = roomName;
        }

        private void DeleteRoom()
        {
            string _disappearingRoom = disappearingRoomComboBox.Text;
            ObservableCollection<Room> rooms = _app._roomController.Read();
            foreach (Room room in rooms)
            {
                if (room.Name.Equals(_disappearingRoom))
                {
                    _app._roomController.Delete(room.Id);
                    break;
                }
            }
        }

        private void ReplaceEquipment()
        {
            string _expandingRoom = expandingRoomComboBox.Text;
            string _disappearingRoom = disappearingRoomComboBox.Text;
            ObservableCollection<Equipment> equipments = _app._equipmentController.Read();
            foreach (Equipment equipment in equipments)
            {
                if (equipment.Room.Equals(_disappearingRoom))
                {
                    Equipment equipment1 = new Equipment(equipment.Id, equipment.Number, equipment.Name, _expandingRoom);
                    _app._equipmentController.Edit(equipment1);
                }
            }
        }

        private void MergeClick(object sender, RoutedEventArgs e)
        {
            DeleteRoom();
            ReplaceEquipment();
            _roomOccupancy.BackToRoomOccupancy();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            _roomOccupancy.BackToRoomOccupancy();
        }
        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
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
    }
}
