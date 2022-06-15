using Hospital.Controller;
using Hospital.Model;
using Hospital.View.ManagerView.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        private App _app;
        private Room room;
        private RoomController _roomController;
        public AddRoomWindow(ManagerWindow managerWindow, RoomController roomController)
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _roomController = roomController;
            room = new Room();
            InitializeComponent();
            var viewModel = new AddRoomViewModel(_app._roomController);
            DataContext = viewModel;
            viewModel.OnRequestClose += (s, e) => Close();

        }
        


        /*
        
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
                Floor =floorText.Text,
                Type = typeComboBox.Text
            };

            if (idText.Text.Equals(""))
            {
                validationName.Visibility = Visibility.Visible;
                validationFloor.Visibility = Visibility.Hidden;
                validationFloorInt.Visibility = Visibility.Hidden;
                return;
            }

            if (floorText.Text.Equals(""))
            {
                validationFloor.Visibility = Visibility.Visible;
                validationName.Visibility = Visibility.Hidden;
                validationFloorInt.Visibility = Visibility.Hidden;
                return;
            }

            int outputValue = 0;
            bool isNumber = false;

            isNumber = Int32.TryParse(floorText.Text, out outputValue);

            if(!isNumber)
            {
                validationFloor.Visibility = Visibility.Hidden;
                validationName.Visibility = Visibility.Hidden;
                validationFloorInt.Visibility = Visibility.Visible;
                return;
            }

            validationFloor.Visibility = Visibility.Hidden;
            validationName.Visibility = Visibility.Hidden;
            _roomController.Create(newRoom);
            ManagerWindow managerWindow = new ManagerWindow(_app._roomController);
            managerWindow.Show();
            Close();
        }*/
        
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
            View.ManagerView.MedicineWindow medicine = new View.ManagerView.MedicineWindow(_app._medicineController);
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
