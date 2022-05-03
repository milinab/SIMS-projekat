using Hospital.Model;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Repository;

namespace Hospital.Service
{
    public class RoomService
    {
        private int _id;
        private readonly RoomRepository _repository;

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
                _id = rooms.Last().Id;
            }
        }

        public Room ReadById(int id)
        {
            return _repository.ReadById(id);
        }
      
        public void Create(Room newRoom)
        {
            newRoom.Id = GenerateId();
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
        
        private int GenerateId()
        {
            return ++_id;
        }
    }
}