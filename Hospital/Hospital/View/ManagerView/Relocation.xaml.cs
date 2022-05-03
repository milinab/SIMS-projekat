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
            roomComboBox.ItemsSource = roomName;
            roomComboBox2.ItemsSource = roomName;
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
    }
}
