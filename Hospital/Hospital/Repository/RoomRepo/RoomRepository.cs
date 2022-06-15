using Hospital.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Repository.RoomRepo
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Serializer<Room> _serializer;

        public RoomRepository()
        {
            _serializer = new Serializer<Room>("rooms.csv");
        }
   
        public List<Room> Read()
        {
            return _serializer.Read();
        }

        public Room ReadById(int id)
        {
            foreach (Room room in Read())
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
            var list = Read();
            list.Add(newRoom);
            Write(list);
        }

        public void Edit(Room editRoom)
        {
            var list = Read();
            foreach (Room room in list)
            {
                if (room.Id.Equals(editRoom.Id))
                {
                    room.Name = editRoom.Name;
                    room.Floor = editRoom.Floor;
                    room.Type = editRoom.Type;
                }
            }
            Write(list);
        }

        public void Delete(int id)
        {
            var list = Read();
            foreach (var resp in list.Where(resp => resp.Id == id))
            {
                list.Remove(resp);
            }
            Write(list);
        }

        public void Write(List<Room> list)
        {
            _serializer.Write(list);
        }
    }
}