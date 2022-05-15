using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class MedicineRepository
    {
        private ObservableCollection<Medicine> _medicine;
        private readonly Serializer<Medicine> _serializer;

        public MedicineRepository()
        {
            _serializer = new Serializer<Medicine>("medicine.csv");
            _medicine = new ObservableCollection<Medicine>();
        }

        public ObservableCollection<Medicine> Read()
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
                    m.Description = editMedicine.Description;
                    m.Number = editMedicine.Number;
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
