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

        public EquipmentWindow(EquipmentController equipmentController)
        {
            InitializeComponent();
            _content = Content;
            _equipmentController = equipmentController;
            dataGridEquipment.ItemsSource = _equipmentController.Read();

        }

        private void RelocationClick(object sender, RoutedEventArgs e)
        {
            Relocation relocation = new Relocation((Equipment)dataGridEquipment.SelectedItem, _equipmentController);
            relocation.Show();
        }

    }
}
