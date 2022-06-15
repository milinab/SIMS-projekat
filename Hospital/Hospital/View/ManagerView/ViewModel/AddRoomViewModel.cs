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
    public class AddRoomViewModel : ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private RoomController _roomController;
        private App _app;

        public RelayCommand FinishCommand { get; set; }

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

      
        public AddRoomViewModel(RoomController roomController)
        {
            _roomController = roomController;
            List<Room> roomList = _roomController.Read();
            ObservableCollection<Room> rooms = new ObservableCollection<Room>(roomList);
            RoomTypes = new ObservableCollection<string>();
            foreach (Room room in rooms)
            {
                RoomTypes.Add(room.Type);
            }
           
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
           
        }

        private void Execute()
        {
            Room room = new Room
            {
                Name = RoomName,
                Floor =  Floor,
                Type = RoomType
            };
            _roomController.Create(room);
            ManagerWindow managerWindow = new ManagerWindow(_roomController);
            managerWindow.Show();
            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }

        private bool CanExecute()
        {
            if(string.IsNullOrEmpty(_roomType))
            {
                return false; 
            }
            if (string.IsNullOrEmpty(_floor))
            {
                return false;
            }
            if (string.IsNullOrEmpty(_roomName))
            {
                return false;
            }
            return true;
        }

    }
}
