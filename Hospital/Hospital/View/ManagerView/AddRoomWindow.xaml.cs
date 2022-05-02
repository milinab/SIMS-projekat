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

        public AddRoomWindow(ManagerWindow managerWindow, RoomController roomController)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _roomController = roomController;
        }

        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
            Room newRoom = new Room
            {
                Name = idText.Text,
                Floor = int.Parse(floorText.Text),
                Type = typeComboBox.Text



            };
            _roomController.Create(newRoom);
            DialogResult = true;
        }

        private void CancelRoomClick(object sender, RoutedEventArgs e)
            {
                DialogResult = false;
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

    }
}
