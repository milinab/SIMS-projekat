using Hospital.Model;
using System.Collections.ObjectModel;
using Hospital.Service;

namespace Hospital.Controller
{
    public class RoomController
    {
        private readonly RoomService _service;

        public RoomController(RoomService service)
        {
            _service = service;
        }

        public Room ReadById(int id)
        {
            return _service.ReadById(id);
        }
      
        public void Create(Room newRoom)
        {
            _service.Create(newRoom);
        }
      
        public void Edit(Room editRoom)
        {
            _service.Edit(editRoom);
        }
      
        public void Delete(int id)
        {
            _service.Delete(id);
        }
      
        public ObservableCollection<Room> Read()
        {
            return _service.Read();
        }
    }
}