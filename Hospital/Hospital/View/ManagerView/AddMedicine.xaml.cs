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
using Hospital.Model;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for AddMedicine.xaml
    /// </summary>
    public partial class AddMedicine : Window
    {
        private MedicineController _medicineController;
        private MedicineWindow Medicine;
        private App _app;
        public AddMedicine(MedicineWindow medicineWindow, MedicineController medicineController)
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _medicineController = medicineController;
        }

        private void AddMedicineClick(object sender, RoutedEventArgs e)
        {
            Medicine newMedicine = new Medicine
            {
                Name = nameText.Text,
                Description = ingredientsText.Text,
                Number = int.Parse(quantityText.Text)

            };
            _medicineController.Create(newMedicine);
            DialogResult = true;
            MedicineWindow medicineWindow = new MedicineWindow(_app._medicineController);
            medicineWindow.Show();
            Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            MedicineWindow medicineWindow = new MedicineWindow(_app._medicineController);
            medicineWindow.Show();
            Close();
        }
    }
}
