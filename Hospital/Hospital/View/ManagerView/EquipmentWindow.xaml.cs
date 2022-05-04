using Hospital.Controller;
using Hospital.Model;
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
    /// Interaction logic for EquipmentWindow.xaml
    /// </summary>
    public partial class EquipmentWindow : Window
    {
        private readonly object _content;
        private readonly EquipmentController _equipmentController;
        private readonly RoomController _roomController;

        public EquipmentWindow(EquipmentController equipmentController)
        {
            InitializeComponent();
            _content = Content;
            _equipmentController = equipmentController;
            dataGridEquipment.ItemsSource = _equipmentController.Read();

        }

        private void RelocationClick(object sender, RoutedEventArgs e)
        {
            Equipment equipment = dataGridEquipment.SelectedItem as Equipment;
            var editEquipment = new Relocation(equipment, this, _equipmentController, _roomController);
            Content = editEquipment;
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
    }
}
