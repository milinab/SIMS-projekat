using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.MedicineReplaceRepo
{
    public class MedicineReplaceRepository
    {

        private List<ReplacementMedicine> _medicineReplace;
        private readonly Serializer<ReplacementMedicine> _serializer;

        public MedicineReplaceRepository() 
        {
            _serializer = new Serializer<ReplacementMedicine>("medicineReplace.csv");
            _medicineReplace = new List<ReplacementMedicine>();
        }

        public List<ReplacementMedicine> Read()
        {
            _medicineReplace = _serializer.Read();
            return _medicineReplace;
        }
        public ReplacementMedicine ReadById(int id)
        {
            foreach(ReplacementMedicine medicineReplace in _medicineReplace)
            {
                if(medicineReplace.Id.Equals(id))
                    return medicineReplace;
            }    
            return null;
        }
        public void Create(ReplacementMedicine newMedicineReplace)
        {
            _medicineReplace.Add(newMedicineReplace);
            Write();
        }

        private void Write()
        {
            _serializer.Write(_medicineReplace);
        }

        public void Edit(ReplacementMedicine editMedicineReplace)
        {
            foreach (ReplacementMedicine medicineReplace in _medicineReplace)
            {
                if(editMedicineReplace.Id.Equals(medicineReplace.Id))
                {
                    medicineReplace.Name = editMedicineReplace.Name;
                    medicineReplace.Type = editMedicineReplace.Type;
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
