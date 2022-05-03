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
    /// Interaction logic for EditRoom.xaml
    /// </summary>
    public partial class EditRoom : Page
    {
        private int _id;
        private string _name;
        private int _floor;
        private string _type;
        private readonly ManagerWindow _managerWindow;
        private readonly App _app;

        public EditRoom(Room room, ManagerWindow managerWindow)
        {
            InitializeComponent();
            _app = Application.Current as App;
            _managerWindow = managerWindow;
            this.nameText.Text = room.Name;
            this.floorText.Text = room.Floor;
            this.typeComboBox.Text = room.Type;
            _id = room.Id;
        }


        public void EditRoomClick(Object sender, RoutedEventArgs e)
        {
            Room room = new Room(nameText.Text, floorText.Text, typeComboBox.Text, _id);
            _app._roomController.Edit(room);
            _managerWindow.BackToManagerWindow();
        }

        public void CancelRoomClick(object sender, RoutedEventArgs e)
        {
            _managerWindow.BackToManagerWindow();
        }
    }
}
