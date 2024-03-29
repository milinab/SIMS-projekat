﻿using Hospital.Controller;
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
    /// Interaction logic for RejectedMedicineWindow.xaml
    /// </summary>
    public partial class RejectedMedicineWindow : Window
    {
        private MedicineController _medicineController;
        private App _app;
        private Medicine medicine1;
        public RejectedMedicineWindow(MedicineController medicineController)
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _medicineController = medicineController;
            medicine1 = new Medicine();
            var medicines = _app._medicineController.Read();
            foreach (var medicine in medicines)
            {
                if(medicine.Status == Enums.MedicineStatus.Rejected)
                {
                    medicine1 = medicine;
                }
            }
            nameText.Text = medicine1.Name;
            TypeText.Text = medicine1.Type;
            quantityText.Text = medicine1.Number.ToString();
            ingredientsText.Text = medicine1.Ingredients;
        }

        private void NameValidation()
        {
            validationName.Visibility = Visibility.Hidden;
            validationType.Visibility = Visibility.Hidden;
            validationName.Visibility = Visibility.Visible;
            validationIngredients.Visibility = Visibility.Hidden;
        }

        private void TypeValidation()
        {
            validationQuantity.Visibility = Visibility.Hidden;
            validationName.Visibility = Visibility.Hidden;
            validationType.Visibility = Visibility.Visible;
            validationIngredients.Visibility = Visibility.Hidden;
        }

        private void QuantityValidation()
        {
            validationName.Visibility = Visibility.Hidden;
            validationType.Visibility = Visibility.Hidden;
            validationQuantity.Visibility = Visibility.Visible;
            validationIngredients.Visibility = Visibility.Hidden;
        }

        private void IngredientsValidation()
        {
            validationIngredients.Visibility = Visibility.Visible;
            validationName.Visibility = Visibility.Hidden;
            validationType.Visibility = Visibility.Hidden;
            validationQuantity.Visibility = Visibility.Hidden;

        }

        private void HideValidationMessages()
        {
            validationName.Visibility = Visibility.Hidden;
            validationQuantity.Visibility = Visibility.Hidden;
            validationType.Visibility = Visibility.Hidden;
            validationIngredients.Visibility = Visibility.Hidden;
        }

        private void ReopenMedicineWindow()
        {
            MedicineWindow medicineWindow = new MedicineWindow(_app._medicineController);
            medicineWindow.Show();
            Close();
        }

        private void CreateMedicine()
        {
            Medicine newMedicine = new Medicine
            {
                Id = medicine1.Id,
                Name = nameText.Text,
                Type = TypeText.Text,
                Number = int.Parse(quantityText.Text),
                Ingredients = ingredientsText.Text,
                Status = Enums.MedicineStatus.Awaiting
            };
            _medicineController.Edit(newMedicine);
        }

        private void AddMedicineClick(object sender, RoutedEventArgs e)
        {
            if (nameText.Text.Equals(""))
            {
                NameValidation();
                return;
            }
            else if (TypeText.Text.Equals(""))
            {
                TypeValidation();
                return;
            }
            else if (quantityText.Text.Equals(""))
            {
                QuantityValidation();
                return;
            }
            else if (ingredientsText.Text.Equals(""))
            {
                IngredientsValidation();
                return;
            }
            HideValidationMessages();
            CreateMedicine();
            DialogResult = true;
            ReopenMedicineWindow();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            MedicineWindow medicineWindow = new MedicineWindow(_app._medicineController);
            medicineWindow.Show();
            Close();
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
        private void SurveyClick(object sender, RoutedEventArgs e)
        {
            SurveySelect surveySelect = new SurveySelect();
            surveySelect.Show();
            Close();
        }

    }
}
