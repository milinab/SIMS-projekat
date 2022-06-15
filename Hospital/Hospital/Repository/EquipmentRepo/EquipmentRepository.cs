using System.Collections.Generic;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.EquipmentRepo
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly Serializer<Equipment> _serializer;

        public EquipmentRepository()
        {
            _serializer = new Serializer<Equipment>("equipment.csv");
        }

        public List<Equipment> Read()
        {
            return _serializer.Read();
        }

        public Equipment ReadById(int id)
        {
            return Read().FirstOrDefault(equipment => equipment.Id.Equals(id));
        }

        public void Create(Equipment newEquipment)
        {
            var list = Read();
            list.Add(newEquipment);
            Write(list);
        }

        public void Edit(Equipment editEquipment)
        {
            var list = Read();
            foreach (var equipment in list.Where(equipment => editEquipment.Id.Equals(equipment.Id)))
            {
                equipment.Name = editEquipment.Name;
                equipment.Number = editEquipment.Number;
                equipment.Room = editEquipment.Room;
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

        public void Write(List<Equipment> list)
        {
            _serializer.Write(list);
        }
    }
}
