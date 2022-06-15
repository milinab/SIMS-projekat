using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.MedicineRepo
{
    public class MedicineRepository
    {
        private List<Medicine> _medicine;
        private readonly Serializer<Medicine> _serializer;

        public MedicineRepository()
        {
            _serializer = new Serializer<Medicine>("medicine.csv");
            _medicine = new List<Medicine>();
        }

        public List<Medicine> Read()
        {
            _medicine = _serializer.Read();
            return _medicine;
        }

        public Medicine ReadById(int id)
        {
            foreach (Medicine m in _medicine)
            {
                if (m.Id.Equals(id))
                    return m;
            }
            return null;
        }
        public void Create(Medicine newMedicine)
        {
            _medicine.Add(newMedicine);
            Write();
        }

        private void Write()
        {
            _serializer.Write(_medicine);
        }

        public void Edit(Medicine editMedicine)
        {
            foreach (Medicine m in _medicine)
            {
                if(editMedicine.Id.Equals(m.Id))
                {
                    m.Name = editMedicine.Name;
                    m.Type = editMedicine.Type;
                    m.Number = editMedicine.Number;
                    m.Status = editMedicine.Status;
                    m.Ingredients = editMedicine.Ingredients;
                    m.AllergenIds = editMedicine.AllergenIds;
                  
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for(int i = _medicine.Count - 1; i>= 0; i--)
            {
                if(_medicine[i].Id.Equals(id))
                    _medicine.Remove(_medicine[i]);
            }
            Write();
        }
    }


}
