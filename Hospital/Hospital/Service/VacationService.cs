using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public void NoPriorityCreate(Vacation newVacation)
        {
            foreach (var vacation in Read())
            {
                if (vacation.Specialization.Equals(newVacation.Specialization))
                {
                    throw new Exception("SpecializatonException");
                }
            }
            
            newVacation.Id = GenerateId();
            _repository.Create(newVacation);
        }

        public void Create(Vacation newVacation)
        {
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