using System.Collections.Generic;
using Hospital.Model;
using Hospital.Repository;
using System.Linq;
using Hospital.Repository.EquipmentRepo;

namespace Hospital.Service
{
    public class EquipmentService
    {
        private int _id;
        private readonly IEquipmentRepository _repository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _repository = equipmentRepository;
            List<Equipment> equipments = Read();
            if (equipments.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = equipments.Last().Id;
            }
        }

        public Equipment ReadById(int id)
        {
            return _repository.ReadById(id);
        }
      
        public void Create(Equipment newEquipment)
        {
            newEquipment.Id = GenerateId();
            _repository.Create(newEquipment);
        }
      
        public void Edit(Equipment editEquipment)
        {
            _repository.Edit(editEquipment);
        }
      
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
      
        public List<Equipment> Read()
        {
            return _repository.Read();
        }
        
        private int GenerateId()
        {
            return ++_id;
        }
    }
}