using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class MedicalRecordService
    {
        private int _id;
        private readonly MedicalRecordRepository _repository;

        public MedicalRecordService(MedicalRecordRepository medicalRecordRepository)
        {
            _repository = medicalRecordRepository;
            ObservableCollection<MedicalRecord> medicalRecords = Read();
            if (medicalRecords.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = medicalRecords.Last().Id;
            }
        }

        public MedicalRecord ReadById(int id)
        {
            return _repository.ReadById(id);
        }
      
        public void Create(MedicalRecord newMedicalRecord)
        {
            newMedicalRecord.Id = GenerateId();
            _repository.Create(newMedicalRecord);
        }
      
        public void Edit(MedicalRecord editMedicalRecord)
        {
            _repository.Edit(editMedicalRecord);
        }
      
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
      
        public ObservableCollection<MedicalRecord> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}