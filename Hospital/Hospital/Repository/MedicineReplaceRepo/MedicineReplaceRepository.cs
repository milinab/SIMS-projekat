using Hospital.Model;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Repository.MedicineReplaceRepo
{
    public class MedicineReplaceRepository : IMedicineReplaceRepository
    {
        private readonly Serializer<ReplacementMedicine> _serializer;

        public MedicineReplaceRepository() 
        {
            _serializer = new Serializer<ReplacementMedicine>("medicineReplace.csv");
        }

        public List<ReplacementMedicine> Read()
        {
            return _serializer.Read();
        }
        public ReplacementMedicine ReadById(int id)
        {
            foreach(ReplacementMedicine medicineReplace in Read())
            {
                if(medicineReplace.Id.Equals(id))
                    return medicineReplace;
            }    
            return null;
        }
        public void Create(ReplacementMedicine newMedicineReplace)
        {
            var list = Read();
            list.Add(newMedicineReplace);
            Write(list);
        }

        public void Write(List<ReplacementMedicine> list)
        {
            _serializer.Write(list);
        }

        public void Edit(ReplacementMedicine editMedicineReplace)
        {
            var list = Read();
            foreach (var medicineReplace in list.Where(medicineReplace => editMedicineReplace.Id.Equals(medicineReplace.Id)))
            {
                medicineReplace.Name = editMedicineReplace.Name;
                medicineReplace.Type = editMedicineReplace.Type;
                medicineReplace.Number = editMedicineReplace.Number;
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
