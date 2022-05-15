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
    /// Interaction logic for MedicineReplacePage.xaml
    /// </summary>
    public partial class MedicineReplacePage : Page
    {
        private int _id;
        private readonly App _app;
        private readonly MedicineWindow _medicineWindow;
        private readonly MedicineReplaceController _medicineReplaceController;
        private readonly MedicineController _medicineController;
        public MedicineReplacePage(MedicineWindow medicineWindow, Medicine medicine, MedicineController medicineController)
        {
            InitializeComponent();
            _app = Application.Current as App;
            _medicineWindow = medicineWindow;
            dataGridMedicine.ItemsSource = _app._medicineReplaceController.Read().Where(x => x.Description.Contains(medicine.Description));
            _medicineController = medicineController;
            _id = medicine.Id;
        }

        public void CancelReplacementClick(object sender, RoutedEventArgs e)
        {
            _medicineWindow.BackToMedicineWindow();
        }
        public void ReplacementClick(object sender, RoutedEventArgs e)
        {
            MedicineReplace medicineReplace = dataGridMedicine.SelectedValue as MedicineReplace;
            Medicine newMedicine = new Medicine
            {
                Name = medicineReplace.Name,
                Description = medicineReplace.Description,
                Number = medicineReplace.Number
            };
            _medicineController.Create(newMedicine);

            ObservableCollection<Medicine> medicines = _app._medicineController.Read();
            foreach(Medicine medic in medicines)
            {
                if(medic.Id.Equals(_id))
                {
                    _app._medicineController.Delete(_id);
                    break;
                }
            }
            MedicineWindow medicineWindow = new MedicineWindow(_app._medicineController);
            medicineWindow.Show();
        }
    }
}
