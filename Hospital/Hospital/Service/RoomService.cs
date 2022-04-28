using ClassDiagram.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class RoomService
    {
        private int _id;
        public readonly RoomRepository _repository;

        public RoomService(RoomRepository roomRepository)
        {
            _repository = roomRepository;
            ObservableCollection<Room> rooms = Read();
            if (rooms.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = int.Parse(rooms.Last().Id);
            }
        }

        public Room ReadById(int id)
        {
            return _repository.ReadById(id);
        }
      
        public void Create(Room newRoom)
        {
            _repository.Create(newRoom);
        }
      
        public void Edit(Room editRoom)
        {
            _repository.Edit(editRoom);
        }
      
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
      
        public ObservableCollection<Room> Read()
        {
            return _repository.Read();
        }
    }
}