using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class EquipmentController
    {
        private readonly EquipmentService _service;

        public EquipmentController(EquipmentService service)
        {
            _service = service;
        }

        public Equipment ReadById(int id)
        {
            return _service.ReadById(id);
        }
      
        public void Create(Equipment newEquipment)
        {
            _service.Create(newEquipment);
        }
      
        public void Edit(Equipment editEquipment)
        {
            _service.Edit(editEquipment);
        }
      
        public void Delete(int id)
        {
            _service.Delete(id);
        }
      
        public List<Equipment> Read()
        {
            return _service.Read();
        }
    }
}