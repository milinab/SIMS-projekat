using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository.MedicalRecordRepo;
using Hospital.Repository.AddressRepo;

namespace Hospital.Repository.PatientRepo
{
    public class PatientRepository
    {
        private List<Patient> _patients;
        private readonly Serializer<Patient> _serializer;
        private readonly AddressRepository _addressRepository;
        private readonly MedicalRecordRepository _medicalRecordRepository;
        
        public PatientRepository(AddressRepository addressRepository, MedicalRecordRepository medicalRecordRepository)
        {
            _serializer = new Serializer<Patient>("patients.csv");
            _patients = new List<Patient>();
            _addressRepository = addressRepository;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public List<Patient> Read()
        {
            _patients = _serializer.Read();
            
            foreach (var patient in _patients)
            {
                Address address = _addressRepository.ReadById(patient.AddressId);
                MedicalRecord medicalRecord = _medicalRecordRepository.ReadById(patient.MedicalRecordId);
                if (address != null)
                {
                    patient.Address = address;
                }
                if (medicalRecord != null)
                {
                   patient.MedicalRecord = medicalRecord;
                }
            }
            return _patients;
        }

        public Patient ReadById(int id)
        {
            foreach (var patient in _patients)
            {
                if (patient.Id == id)
                {
                    Address address = _addressRepository.ReadById(patient.AddressId);
                    MedicalRecord medicalRecord = _medicalRecordRepository.ReadById(patient.MedicalRecordId);
                    if (address != null)
                    {
                        patient.Address = address;
                    }
                    if (medicalRecord != null)
                    {
                        patient.MedicalRecord= medicalRecord;
                    }
                    return patient;
                }
            }
            return null;
        }
        public Patient ReadByIdTest(int id)
        {
            foreach (var patient in _patients)
            {
                if (patient.Id == id)
                {
                    Address address = _addressRepository.ReadById(patient.AddressId);
                    if (address != null)
                    {
                        patient.Address = address;
                    }
                    return patient;
                }
            }
            return null;
        }

        public void Create(Patient newPatient)
        {
            _patients.Add(newPatient);
            Write();
        }

        public void Edit(Patient editPatient)
        {
            foreach (Patient patient in _patients)
            {
                if (patient.Id.Equals(editPatient.Id))
                {
                    patient.HealthInsuranceId = editPatient.HealthInsuranceId;
                    patient.IdNumber = editPatient.IdNumber;
                    patient.LastName = editPatient.LastName;
                    patient.Name = editPatient.Name;
                    patient.Password = editPatient.Password;
                    patient.Phone = editPatient.Phone;
                    patient.Username = editPatient.Username;
                    patient.BloodType = editPatient.BloodType;
                    patient.DateOfBirth = editPatient.DateOfBirth;
                    patient.Email = editPatient.Email;
                    patient.Gender = editPatient.Gender;
                    patient.IsActive = editPatient.IsActive;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _patients.Count - 1; i >= 0; i--)
            {
                if (_patients[i].Id.Equals(id))
                {
                    _patients.Remove(_patients[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_patients);
        }

        public Patient ReadByUsername(string username)
        {
            _patients = _serializer.Read();
            foreach (Patient user in _patients)
            {
                if (user.Username == username)
                {
                    Address address = _addressRepository.ReadById(user.AddressId);
                    if (address != null)
                    {
                        user.Address = address;
                        return user;
                    }
                    return user;
                }
            }
            return null;
        }
    }
}