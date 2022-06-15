using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Repository.MedicineReplaceRepo;

namespace Hospital.Service
{
    public class MedicineReplaceService
    {
        private int _id;
        private readonly IMedicineReplaceRepository _repository;

        public MedicineReplaceService(IMedicineReplaceRepository medicineReplaceRepository)
        {
            _repository = medicineReplaceRepository;
            List<ReplacementMedicine> medicineReplace = Read();
            if(medicineReplace != null)
                _id = int.Parse(medicineReplace.Last().Id);
            else
                _id = 0;

        }
        public ReplacementMedicine ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(ReplacementMedicine newMedicineReplace)
        {
            newMedicineReplace.Id = GenerateId().ToString();
            _repository.Create(newMedicineReplace);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public void Edit(ReplacementMedicine editMedicineReplace)
        {
            _repository.Edit(editMedicineReplace);
        }
        public List<ReplacementMedicine>Read()
        {
            return _repository.Read();
        }
        private int GenerateId()
        {
            return ++_id;
        }
    }
}
