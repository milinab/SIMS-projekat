using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hospital.Model
{
    public class MedicalRecordController
    {
        private readonly MedicalRecordService _service;
        public MedicalRecordController(MedicalRecordService service)
        {
            _service = service;
        }

        public MedicalRecord ReadById(int id)
        {
            return _service.ReadById(id);
        }
      
        public void Create(MedicalRecord newMedicalRecord)
        {
            _service.Create(newMedicalRecord);
        }
      
        public void Edit(MedicalRecord editMedicalRecord)
        {
            _service.Edit(editMedicalRecord);
        }
      
        public void Delete(int id)
        {
            _service.Delete(id);
        }
      
        public ObservableCollection<MedicalRecord> Read()
        {
            return _service.Read();
        }
    }
}