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
        private readonly MedicineController _medicineController;
        public MedicineReplacePage(MedicineWindow medicineWindow, Medicine medicine, MedicineController medicineController)
        {
            InitializeComponent();
            _app = Application.Current as App;
            _medicineWindow = medicineWindow;
            dataGridMedicine.ItemsSource = _app._medicineReplaceController.Read().Where(x => x.Type.Contains(medicine.Type));
            _medicineController = medicineController;
            _id = medicine.Id;
        }

        public void CancelReplacementClick(object sender, RoutedEventArgs e)
        {
            _medicineWindow.BackToMedicineWindow();
        }

        private bool ReplacementValidation()
        {
            ReplacementMedicine medicineReplace = dataGridMedicine.SelectedValue as ReplacementMedicine;
            if (medicineReplace == null)
            {
                validationSelection.Visibility = Visibility.Visible;
                return true;
            }
            return false;
        }

        private void HideValidationMassage()
        {

            validationSelection.Visibility = Visibility.Hidden;
        }

        private void CreateMedicine()
        {

        }

        private void ReplaceMedicine()
        {
            ReplacementMedicine medicineReplace = dataGridMedicine.SelectedValue as ReplacementMedicine;
            if (ReplacementValidation())
                return;
            HideValidationMassage();
            Medicine newMedicine = new Medicine
            {
                Name = medicineReplace.Name,
                Type = medicineReplace.Type,
                Number = medicineReplace.Number,
                Ingredients = medicineReplace.Ingredients
            };
            _medicineController.Create(newMedicine);
        }

        private void DeleteMedicine()
        {
            if (ReplacementValidation())
                return;
            ObservableCollection<Medicine> medicines = _app._medicineController.Read();
            foreach (Medicine medic in medicines)
            {
                if (medic.Id.Equals(_id))
                {
                    _app._medicineController.Delete(_id);
                    break;
                }
            }
        }

        public void ReplacementClick(object sender, RoutedEventArgs e)
        {
            ReplaceMedicine();
            DeleteMedicine();
            if (ReplacementValidation())
                return;
            MedicineWindow medicineWindow = new MedicineWindow(_app._medicineController);
            medicineWindow.Show();
        }
        private void EquipmentClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.EquipmentWindow equipmentWindow = new View.ManagerView.EquipmentWindow(_app._equipmentController);
            equipmentWindow.Show();
        }
        private void RoomClick(object sender, RoutedEventArgs e)
        {

            View.ManagerView.ManagerWindow roomWindow = new View.ManagerView.ManagerWindow(_app._roomController);
            roomWindow.Show();
        }

        private void OccupancyClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.RoomOccupancy roomOccupancy = new View.ManagerView.RoomOccupancy(_app._appointmentController, _app._roomController);
            roomOccupancy.Show();
        }
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.ManagerHomeWindow managerHomeWindow = new ManagerHomeWindow();
            managerHomeWindow.Show();
        }
        private void MedicineClick(object sender, RoutedEventArgs e)
        {
            MedicineWindow medicine = new MedicineWindow(_app._medicineController);
            medicine.Show();
        }
        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
        }
        private void SurveyClick(object sender, RoutedEventArgs e)
        {
            SurveySelect surveySelect = new SurveySelect();
            surveySelect.Show();
        }
    }
}
