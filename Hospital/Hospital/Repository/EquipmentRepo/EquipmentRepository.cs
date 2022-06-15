using System.Collections.Generic;
using Hospital.Model;

namespace Hospital.Repository.EquipmentRepo
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private List<Equipment> _equipments;
        private readonly Serializer<Equipment> _serializer;

        public EquipmentRepository()
        {
            _serializer = new Serializer<Equipment>("equipment.csv");
            _equipments = new List<Equipment>();
        }

        public List<Equipment> Read()
        {
            _equipments = _serializer.Read();
            return _equipments;
        }

        public Equipment ReadById(int id)
        {
            foreach (Equipment equipment in _equipments)
            {
                if (equipment.Id.Equals(id))
                {
                    return equipment;
                }
            }
            return null;
        }

        public void Create(Equipment newEquipment)
        {
            _equipments.Add(newEquipment);
            Write();
        }

        public void Edit(Equipment editEquipment)
        {
            foreach (Equipment equipment in _equipments)
            {
                if (editEquipment.Id.Equals(equipment.Id))
                {
                    equipment.Name = editEquipment.Name;
                    equipment.Number = editEquipment.Number;
                    equipment.Room = editEquipment.Room;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _equipments.Count - 1; i >= 0; i--)
            {
                if (_equipments[i].Id.Equals(id))
                {
                    _equipments.Remove(_equipments[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_equipments);
        }
    }
}
