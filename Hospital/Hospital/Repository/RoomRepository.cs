using ClassDiagram.Model;
using Hospital.Repository;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Model
{
    public class RoomRepository
    {
        private ObservableCollection<Room> _rooms;
        private readonly Serializer<Room> _serializer;

        public RoomRepository()
        {
            _serializer = new Serializer<Room>("rooms.csv");
            _rooms = new ObservableCollection<Room>();
        }
   
        public ObservableCollection<Room> Read()
        {
            _rooms = _serializer.Read();
            return _rooms;
        }

        public Room ReadById(int id)
        {
            foreach (Room room in _rooms)
            {
                if (room.Id.Equals(id))
                {
                    return room;
                }
            }
            return null;
        }

        public void Create(Room newRoom)
        {
            _rooms.Add(newRoom);
            Write();
        }

        public void Edit(Room editRoom)
        {
            foreach (Room room in _rooms)
            {
                if (room.Id.Equals(editRoom.Id))
                {
                    room.Type = editRoom.Type;
                    room.Equipment = editRoom.Equipment;
                }
            }
        }

        public void Delete(int id)
        {
            for (int i = _rooms.Count - 1; i >= 0; i--)
            {
                if (_rooms[i].Id.Equals(id))
                {
                    _rooms.Remove(_rooms[i]);
                }
            }
            Write();
        }
   
        public void Write()
        {
            _serializer.Write(_rooms);
        }
    }
}