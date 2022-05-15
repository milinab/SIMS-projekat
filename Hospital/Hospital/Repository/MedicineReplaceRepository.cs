using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class MedicineReplaceRepository
    {

        private ObservableCollection<MedicineReplace> _medicineReplace;
        private readonly Serializer<MedicineReplace> _serializer;

        public MedicineReplaceRepository() 
        {
            _serializer = new Serializer<MedicineReplace>("medicineReplace.csv");
            _medicineReplace = new ObservableCollection<MedicineReplace>();
        }

        public ObservableCollection<MedicineReplace> Read()
        {
            _medicineReplace = _serializer.Read();
            return _medicineReplace;
        }
        public MedicineReplace ReadById(int id)
        {
            foreach(MedicineReplace medicineReplace in _medicineReplace)
            {
                if(medicineReplace.Id.Equals(id))
                    return medicineReplace;
            }    
            return null;
        }
        public void Create(MedicineReplace newMedicineReplace)
        {
            _medicineReplace.Add(newMedicineReplace);
            Write();
        }

        private void Write()
        {
            _serializer.Write(_medicineReplace);
        }

        public void Edit(MedicineReplace editMedicineReplace)
        {
            foreach (MedicineReplace medicineReplace in _medicineReplace)
            {
                if(editMedicineReplace.Id.Equals(medicineReplace.Id))
                {
                    medicineReplace.Name = editMedicineReplace.Name;
                    medicineReplace.Description = editMedicineReplace.Description;
                    medicineReplace.Number = editMedicineReplace.Number;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for(int i = _medicineReplace.Count -1; i >= 0; i--)
            {
                if(_medicineReplace[i].Id.Equals(id))
                    _medicineReplace.Remove(_medicineReplace[i]);
            }
            Write();
        }
    }
}
