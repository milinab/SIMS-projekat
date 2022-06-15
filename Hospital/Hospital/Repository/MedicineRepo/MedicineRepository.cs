using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.MedicineRepo
{
    public class MedicineRepository: IMedicineRepository
    {
        private readonly Serializer<Medicine> _serializer;

        public MedicineRepository()
        {
            _serializer = new Serializer<Medicine>("medicine.csv");
        }

        public List<Medicine> Read()
        {
            return _serializer.Read();
        }

        public Medicine ReadById(int id)
        {
            return Read().FirstOrDefault(m => m.Id.Equals(id));
        }
        public void Create(Medicine newMedicine)
        {
            var list = Read();
            list.Add(newMedicine);
            Write(list);
        }

        public void Write(List<Medicine> list)
        {
            _serializer.Write(list);
        }

        public void Edit(Medicine editMedicine)
        {
            var list = Read();
            foreach (var m in list.Where(m => editMedicine.Id.Equals(m.Id)))
            {
                m.Name = editMedicine.Name;
                m.Type = editMedicine.Type;
                m.Number = editMedicine.Number;
                m.Status = editMedicine.Status;
                m.Ingredients = editMedicine.Ingredients;
                m.AllergenIds = editMedicine.AllergenIds;
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
    }


}
