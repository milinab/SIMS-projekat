using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.MedicalRecordRepo;

namespace Hospital.Repository.PatientRepo
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Serializer<Patient> _serializer;
        private readonly AddressRepo.AddressRepository _addressRepository;
        private readonly MedicalRecordRepository _medicalRecordRepository;
        
        public PatientRepository(AddressRepo.AddressRepository addressRepository, MedicalRecordRepository medicalRecordRepository)
        {
            _serializer = new Serializer<Patient>("patients.csv");
            _addressRepository = addressRepository;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public List<Patient> Read()
        {
            var patients = _serializer.Read();
            
            foreach (var patient in patients)
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
            return patients;
        }

        public Patient ReadById(int id)
        {
            foreach (var patient in Read())
            {
                if (patient.Id != id)
                {
                    continue;
                }
                
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
            return null;
        }
        public Patient ReadByIdTest(int id)
        {
            foreach (var patient in Read())
            {
                if (patient.Id != id)
                {
                    continue;
                }
                
                Address address = _addressRepository.ReadById(patient.AddressId);
                if (address != null)
                {
                    patient.Address = address;
                }
                return patient;
            }
            return null;
        }

        public void Create(Patient newPatient)
        {
            var list = Read();
            list.Add(newPatient);
            Write(list);
        }

        public void Edit(Patient editPatient)
        {
            var list = Read();
            foreach (var patient in list.Where(patient => patient.Id.Equals(editPatient.Id)))
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

        public void Write(List<Patient> list)
        {
            _serializer.Write(list);
        }

        public Patient ReadByUsername(string username)
        {
            foreach (Patient user in Read())
            {
                if (user.Username != username)
                {
                    continue;
                }
                Address address = _addressRepository.ReadById(user.AddressId);
                if (address == null)
                {
                    return user;
                }
                user.Address = address;
                return user;
            }
            return null;
        }
    }
}