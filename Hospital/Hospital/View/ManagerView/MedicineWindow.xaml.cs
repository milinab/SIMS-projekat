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
    /// Interaction logic for Medicine.xaml
    /// </summary>
    public partial class MedicineWindow : Window
    {
        private App _app;
        private readonly object _content;
        private readonly MedicineController _medicineController;

        public MedicineWindow(MedicineController medicineController)
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _content = Content;
            _medicineController = medicineController;
            dataGridMedicine.ItemsSource = _medicineController.Read();

        }

        private void AddMedicineClick(object sender, RoutedEventArgs e)
        {
            AddMedicine addMedicine = new AddMedicine(this, _medicineController);
            addMedicine.ShowDialog();
            Close();
        }

        public void BackToMedicineWindow()
        {
            Content = _content;
        }

        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            Close();
        }











        public MedicineWindow()
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
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
            View.ManagerView.RoomOccupancy roomOccupancy = new View.ManagerView.RoomOccupancy(_app._appointmentController);
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
    }
}
