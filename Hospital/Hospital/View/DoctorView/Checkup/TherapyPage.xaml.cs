using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using ServiceStack;
using Application = System.Windows.Application;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace Hospital.View.DoctorView.Checkup
{
    public partial class TherapyPage
    {
        private ObservableCollection<Medicine> _medicines;
        private App _app;
        private readonly Patient _patient;

        public TherapyPage(Patient patient)
        {
            _app = Application.Current as App;
            _medicines = _app?._medicineController.Read();
            InitializeComponent();
            DataContext = this;
            MedicineListView.ItemsSource = _medicines;
            _patient = patient;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            var selectedMedicine = (Medicine) MedicineListView.SelectedItem;
            var doctorRx = RxTextBox.Text;
            _app._therapyController.Create(new Therapy(selectedMedicine.Name, doctorRx, _patient.Id));
            MainWindow.MainFrame.GoBack();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }

        private void MedicineTextBox_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var filtered = _medicines.Where(medicine => medicine.Name.ToString().ToLower().StartsWith(MedicineTextBox.Text.ToLower()));
            MedicineListView.ItemsSource = filtered;
            if (MedicineTextBox.Text.IsEmpty())
            {
                MedicineListView.ItemsSource = _medicines;
            }
        }

        private void MedicineListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> displayAllergens = new List<string>();
            var allergens = _app._allergenController.Read();
            foreach (var medicine in _medicines)
            {
                if (MedicineListView.SelectedItem == medicine)
                {
                    var allergenIds = medicine.AllergenIds;
                    foreach (var allergen in allergens)
                    {
                        foreach (var allergenId in allergenIds)
                        {
                            if (allergenId == allergen.Id && _patient.MedicalRecord.AllergenIds.Contains(allergen.Id))
                            {
                                if (MessageBox.Show(
                                        "Patient is allergic to the chosen medicine. Are you sure you want to proceed?",
                                        "Warning", MessageBoxButton.YesNo) == MessageBoxResult.No)
                                {
                                    MainWindow.MainFrame.Navigate(new TherapyPage(_patient));
                                    return;
                                }
                                displayAllergens.Add(allergen.Name);
                            }
                        }
                    }
                }
            }

            AllergensTextBlock.Visibility = Visibility.Visible;
            AllergensItemsControl.Visibility = Visibility.Visible;
            AllergensItemsControl.ItemsSource = displayAllergens;

            if (MedicineTextBox.Text.IsEmpty() && MedicineListView.SelectedItem == null )
            {
                AllergensTextBlock.Visibility = Visibility.Hidden;
                AllergensItemsControl.Visibility = Visibility.Hidden;
            }
        }
    }
}