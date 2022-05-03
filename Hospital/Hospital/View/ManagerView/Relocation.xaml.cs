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
    /// Interaction logic for Relocation.xaml
    /// </summary>
    public partial class Relocation : Window
    {

        private EquipmentController _equipmentController;
        private readonly Equipment _equipment;

        public Relocation(Equipment equipment, EquipmentController equipmentController)
        {
            InitializeComponent();
            _equipmentController = equipmentController;
            _equipment = equipment;

        }

        public void RelocateClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
