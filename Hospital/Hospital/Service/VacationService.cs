using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Exceptions;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class VacationService
    {
        private int _id;
        private readonly VacationRepository _repository;
        
        public VacationService(VacationRepository vacationRepository)
        {
            _repository = vacationRepository;
            List<Vacation> vacations = Read();
            _id = vacations.Count == 0 ? 0 : vacations.Last().Id;
        }
        
        public List<Vacation> Read()
        {
            return _repository.Read();
        }

        public Vacation ReadById(int id)
        {
            return _repository.ReadById(id);
        }
        
        private static void ValidateVacationDate(Vacation newVacation)
        {
            if (newVacation.IsStartDateBefore(DateTime.Today.AddDays(2)) ||
                newVacation.IsEndDateBefore(newVacation.StartDate.AddDays(1)))
            {
                throw new VacationException("VacationInvalidDate");
            }
        }
        
        private void ValidateDoctorSpecializationForVacation(Vacation newVacation)
        {
            if (Read().Any(vacation => vacation.Doctor.Specialization.Equals(newVacation.Doctor.Specialization)))
            {
                throw new VacationException("SpecializationException");
            }
        }
        
        private void ValidateDoctorForVacation(Vacation newVacation)
        {
            if (Read().Any(vacation => vacation.Doctor.Equals(newVacation.Doctor)))
            {
                throw new VacationException("DoctorException");
            }
        }

        public void NoPriorityCreate(Vacation newVacation)
        {
            ValidateDoctorForVacation(newVacation);
            ValidateVacationDate(newVacation);
            ValidateDoctorSpecializationForVacation(newVacation);
            newVacation.Id = GenerateId();
            _repository.Create(newVacation);
        }

        public void Create(Vacation newVacation)
        {
            ValidateDoctorForVacation(newVacation);
            ValidateVacationDate(newVacation);
            newVacation.Id = GenerateId();
            _repository.Create(newVacation);
        }

        public void Edit(Vacation editVacation)
        {
            _repository.Edit(editVacation);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}