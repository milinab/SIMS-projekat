using Hospital.Controller;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        private RoomController _roomController;
        private Room Room;
        private App _app;
        private ManagerWindow _managerWindow;
        public AddRoomWindow(ManagerWindow managerWindow, RoomController roomController)
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _managerWindow = managerWindow;
            _roomController = roomController;
        }

        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
            Room newRoom = new Room
            {
                Name = idText.Text,
                Floor = floorText.Text,
                Type = typeComboBox.Text



            };
            _roomController.Create(newRoom);
            ManagerWindow managerWindow = new ManagerWindow(_app._roomController);
            managerWindow.Show();
            Close();
        }

        private void CancelRoomClick(object sender, RoutedEventArgs e)
            {
            ManagerWindow managerWindow = new ManagerWindow(_app._roomController);
            managerWindow.Show();
            Close();
            }


        public AddRoomWindow()
        {
            InitializeComponent();

        }

        public ObservableCollection<Equipment> Equipments
        {
            get;
            set;
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
            MedicineWindow medicine = new MedicineWindow();
            medicine.Show();
            Close();
        }
        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            Close();
        }
        private void SurveyClick(object sender, RoutedEventArgs e)
        {
            SurveySelect surveySelect = new SurveySelect();
            surveySelect.Show();
            Close();
        }
    }
}
