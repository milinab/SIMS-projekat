using ClassDiagram.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class EquipmentService
    {
        private int _id;
        public readonly EquipmentRepository _repository;

        public EquipmentService(EquipmentRepository equipmentRepository)
        {
            _repository = equipmentRepository;
            ObservableCollection<Equipment> equipments = Read();
            if (equipments.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = int.Parse(equipments.Last().Id);
            }
        }

        public Equipment ReadById(int id)
        {
            return _repository.ReadById(id);
        }
      
        public void Create(Equipment newEquipment)
        {
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
      
        public ObservableCollection<Equipment> Read()
        {
            return _repository.Read();
        }
    }
}