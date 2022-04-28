using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Repository;

namespace Hospital.Model
{
    public class MedicalRecordRepository
    {
        private ObservableCollection<MedicalRecord> _medicalRecords;
        private readonly Serializer<MedicalRecord> _serializer;

        public MedicalRecordRepository()
        {
            _serializer = new Serializer<MedicalRecord>("medicalrecords.csv");
            _medicalRecords = new ObservableCollection<MedicalRecord>();
        }

        public MedicalRecord ReadById(int patientId)
        {
            foreach (MedicalRecord medicalRecord in _medicalRecords)
            {
                if (medicalRecord.Id.Equals(patientId))
                {
                    return medicalRecord;
                }
            }
            return null;
        }

        public void Create(MedicalRecord newMedicalRecord)
        {
            _medicalRecords.Add(newMedicalRecord);
            Write();
        }

        public void Edit(MedicalRecord editMedicalRecord)
        {
            foreach (MedicalRecord medicalRecord in _medicalRecords)
            {
                if (medicalRecord.Id.Equals(editMedicalRecord.Id))
                {
                    medicalRecord.ChronicalDiseases = editMedicalRecord.ChronicalDiseases;
                    medicalRecord.Patient = editMedicalRecord.Patient;
                    medicalRecord.Allergies = editMedicalRecord.Allergies;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _medicalRecords.Count - 1; i >= 0; i--)
            {
                if (_medicalRecords[i].Id.Equals(id))
                {
                    _medicalRecords.Remove(_medicalRecords[i]);
                }
            }
            Write();
        }
        public ObservableCollection<MedicalRecord> Read()
        {
            _medicalRecords = _serializer.Read();
            return _medicalRecords;
        }
      
        public void Write()
        {
            _serializer.Write(_medicalRecords);
        }
    }
}