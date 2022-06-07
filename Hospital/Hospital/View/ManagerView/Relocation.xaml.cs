﻿using Hospital.Controller;
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
using System.Windows.Shapes;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for Relocation.xaml
    /// </summary>
    public partial class Relocation : Page
    {
        private string _id;
        private App _app;
        private readonly EquipmentWindow _equipmentWindow;
        private EquipmentController _equipmentController;
        private RoomController _roomController;
        public ObservableCollection<Equipment> equipment
        {
            get;
            set;
        }

        public Relocation(Equipment equipments, EquipmentWindow equipmentWindow, EquipmentController equipmentController, RoomController roomController)
        {

            InitializeComponent();
            _app = Application.Current as App;
            _equipmentWindow = equipmentWindow;
            _equipmentController = equipmentController;
            _roomController = roomController;
            ObservableCollection<Room> rooms = _app._roomController.Read();
            ObservableCollection<String> roomName = new ObservableCollection<string>();
            equipment = _app._equipmentController.Read();
            ObservableCollection<String> eqName = new ObservableCollection<string>();

            foreach (Room room in rooms)
            {
                roomName.Add(room.Name);
            }
            foreach (Equipment eq in equipment)
            {
                eqName.Add(eq.Name);
            }
            eqComboBox.ItemsSource = eqName;
            this.eqComboBox.Text = equipments.Name;
            this.quantityTextBox.Text = equipments.Number;
            this.roomComboBox.Text = equipments.Room;
            _id = equipments.Id;


        }

        public void RelocateClick(object sender, RoutedEventArgs e)
        {
            foreach (var a in equipment)
            {
                TimeSpan dt = (TimeSpan)this.timePicker.Value;
                DateTime now = DateTime.Now;
                DateTime neww = now + dt;
                int diff =(int)(neww - now).TotalSeconds;
                if (diff > 0)
                {
                    Equipment equipment = new Equipment(_id, quantityTextBox.Text, eqComboBox.Text, roomComboBox2.Text);
                    _app._equipmentController.Edit(equipment);
                    _equipmentWindow.BackToEquipmentWindow();
                }
                else
                {
                    
                }
            }
            
        }

        public void CancelClick(object sender, RoutedEventArgs e)
        {
            _equipmentWindow.BackToEquipmentWindow();
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
