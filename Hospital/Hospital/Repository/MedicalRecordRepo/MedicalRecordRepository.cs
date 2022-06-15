using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.MedicalRecordRepo
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly Serializer<MedicalRecord> _serializer;
       
        public MedicalRecordRepository()
        {
            _serializer = new Serializer<MedicalRecord>("medicalrecords.csv");
        }

        public MedicalRecord ReadById(int id)
        {
            return Read().FirstOrDefault(medicalRecord => medicalRecord.Id == id);
        }

        public void Create(MedicalRecord newMedicalRecord)
        {
            var list = Read();
            list.Add(newMedicalRecord);
            Write(list);
        }

        public void Edit(MedicalRecord editMedicalRecord)
        {
            var list = Read();
            foreach (var medicalRecord in list.Where(medicalRecord => medicalRecord.Id.Equals(editMedicalRecord.Id)))
            {
                medicalRecord.ChronicalDiseases = editMedicalRecord.ChronicalDiseases;
                medicalRecord.AllergenIds = editMedicalRecord.AllergenIds;
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
        public List<MedicalRecord> Read()
        {
            return _serializer.Read();
        }
      
        public void Write(List<MedicalRecord> list)
        {
            _serializer.Write(list);
        }
    }
}