using System.Collections.ObjectModel;
using System.Windows;
using Hospital.Enums;
using Hospital.Model;

namespace Hospital.View.DoctorView
{
    public partial class VerifyMedicineUC
    {
        private App _app;
        private ObservableCollection<Medicine> _awaitingMedicines = new ObservableCollection<Medicine>();
        public VerifyMedicineUC()
        {
            _app = Application.Current as App;
            InitializeComponent();
            DataContext = this;
            var medicines = _app._medicineController.Read();
            
            foreach (var medicine in medicines)
            {
                if (medicine.Status == MedicineStatus.Awaiting)
                {
                    _awaitingMedicines.Add(medicine);
                }
            }
            MedicineDataGrid.ItemsSource = _awaitingMedicines;
        }

        private void Accepted_OnClick(object sender, RoutedEventArgs e)
        {
            var editMedicine = (Medicine)MedicineDataGrid.SelectedItem;
            editMedicine.Status = MedicineStatus.Accepted;
            _app._medicineController.Edit(editMedicine);
            _awaitingMedicines.Remove(editMedicine);
            if (_awaitingMedicines.Count == 0)
            {
                MainWindow.MedicineButton.Visibility = Visibility.Hidden;
                MainWindow.MainFrame.GoBack();
            }
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            var editMedicine = (Medicine)MedicineDataGrid.SelectedItem;
            editMedicine.Status = MedicineStatus.Rejected;
            _app._medicineController.Edit(editMedicine);
            MainWindow.MainFrame.GoBack();
            if (_awaitingMedicines.Count == 0)
            {
                MainWindow.MedicineButton.Visibility = Visibility.Hidden;
                MainWindow.MainFrame.GoBack();
            }
        }
    }
}