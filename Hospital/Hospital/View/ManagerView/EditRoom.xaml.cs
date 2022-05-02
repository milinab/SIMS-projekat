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
    public partial class EditRoom : Window
    {
        private RoomController _roomController;
        private readonly Room _room;

        public EditRoom(Room room, RoomController roomController)
        {
            InitializeComponent();
            _room = room;
            _roomController = roomController;
            typeComboBox.Text = _room.Type;
        }


        public void EditRoomClick(Object sender, RoutedEventArgs e)
        {
            string _type = typeComboBox.Text;
            Room _room = new Room
            {
                Name = nameText.Text,
                Floor = int.Parse(floorText.Text),
                Type = _type

            };
            _roomController.Edit(_room);
            Close();
        }

        public void CancelRoomClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
