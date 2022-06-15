using Hospital.Controller;
using Hospital.Core;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.View.ManagerView.ViewModel
{
    public class EditRoomViewModel : ViewModelBase
    {

        public event EventHandler OnRequestClose;
        private RoomController _roomController;
        private readonly ManagerWindow _managerWindow;
        public RelayCommand FinishCommand { get; set; }
        private Room selectedRoom;


        private string _roomName;
        public string RoomName
        {
            get => _roomName;
            set
            {
                _roomName = value;
                OnPropertyChanged(nameof(RoomName));
            }
        }

        private string _roomType;
        public string RoomType
        {
            get => _roomType;
            set
            {
                _roomType = value;
                OnPropertyChanged(nameof(RoomType));
            }
        }

        private string _floor;

        public string Floor
        {
            get => _floor;
            set
            {
                _floor = value;
                OnPropertyChanged(nameof(Floor));
            }
        }
        public ObservableCollection<string> RoomTypes { get; set; }
        public EditRoomViewModel(Room selectedRoom, RoomController roomController)
        {
            _roomController = roomController;
            List<Room> roomList = _roomController.Read();
            ObservableCollection<Room> rooms = new ObservableCollection<Room>(roomList);
            RoomTypes = new ObservableCollection<string>();
            foreach (Room room in rooms)
            {
                RoomTypes.Add(room.Type);
            }

            RoomType = selectedRoom.Type;
            Floor = selectedRoom.Floor;
            RoomName = selectedRoom.Name;
            this.selectedRoom = selectedRoom;
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
        }
        private bool CanExecute()
        {
            if (String.IsNullOrEmpty(_roomType))
            {
                return false;
            }

            return true;
        }
        private void Execute()
        {
            selectedRoom.Floor = Floor;
            selectedRoom.Name = RoomName;
            selectedRoom.Type = RoomType;
            _roomController.Edit(selectedRoom);
            ManagerWindow managerWindow = new ManagerWindow(_roomController);
            managerWindow.Show();
            _managerWindow.BackToManagerWindow();

            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
