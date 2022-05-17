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
using System.Windows.Shapes;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for EquipmentWindow.xaml
    /// </summary>
    public partial class EquipmentWindow : Window
    {
        private App _app;
        private readonly object _content;
        private readonly EquipmentController _equipmentController;
        private readonly RoomController _roomController;

        public EquipmentWindow(EquipmentController equipmentController)
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _content = Content;
            _equipmentController = equipmentController;
            dataGridEquipment.ItemsSource = _equipmentController.Read();
            ObservableCollection<Equipment> equipments = _app._equipmentController.Read();
            ObservableCollection<String> roomNames = new ObservableCollection<string>();
            foreach (Equipment equipment in equipments)
            {
                roomNames.Add(equipment.Room);
            }
            eqComboBox.ItemsSource = roomNames.Distinct();
        }

        private void SearchEquipment(object sender, TextChangedEventArgs e)
        {
            var searchedEquipment = sender as TextBox;
            if (searchedEquipment.Text != "")
            {
                var foundEquipment = _equipmentController.Read().Where(x => x.Name.ToLower().Contains(searchedEquipment.Text.ToLower()));
                dataGridEquipment.ItemsSource = null;
                dataGridEquipment.ItemsSource = foundEquipment;
            }
            else
            {
                dataGridEquipment.ItemsSource = _equipmentController.Read();
            } 
                
        }
        private void FilterEquipment(object sender, SelectionChangedEventArgs e)

        {
            var filteredEquipment = sender as ComboBox;
            if (filteredEquipment.SelectedItem != null)
            {
                var foundEquipment = _equipmentController.Read().Where(x => x.Room.Contains((string)filteredEquipment.SelectedItem));
                dataGridEquipment.ItemsSource = null;
                dataGridEquipment.ItemsSource = foundEquipment;
            }
            else
            {
                dataGridEquipment.ItemsSource = _equipmentController.Read();
            }

        }

        private void RelocationClick(object sender, RoutedEventArgs e)
        {
            Equipment equipment = dataGridEquipment.SelectedItem as Equipment;
            if (equipment == null)
            {
                validacija.Visibility = Visibility.Visible;
                return;
            }
            var editEquipment = new Relocation(equipment, this, _equipmentController, _roomController);
            Content = editEquipment;
            validacija.Visibility = Visibility.Hidden;
        }
        public void BackToEquipmentWindow()
        {
            Content = _content;
            refresh();
        }

        public void refresh()
        {
            dataGridEquipment.ItemsSource = _equipmentController.Read();
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
    }
}
