using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository
{
    public class VacationRepository
    {
        private List<Vacation> _vacations;
        private readonly Serializer<Vacation> _serializer;
        private readonly DoctorRepository _doctorRepository;

        public VacationRepository(DoctorRepository doctorRepository)
        {
            _serializer = new Serializer<Vacation>("vacations.csv");
            _vacations = new List<Vacation>();
            _doctorRepository = doctorRepository;
        }

        public List<Vacation> Read()
        {
            _vacations = _serializer.Read().ToList();
            foreach (var vacation in _vacations)
            {
                var doctor = _doctorRepository.ReadById(vacation.DoctorId);
                if (doctor == null) continue;
                vacation.Doctor = doctor;
            }
            
            return _vacations;
        }

        public Vacation ReadById(int id)
        {
            _vacations = _serializer.Read().ToList();
            return _vacations.FirstOrDefault(vacation => vacation.Id == id);
        }

        public void Create(Vacation newVacation)
        {
            _vacations.Add(newVacation);
            Write();
        }

        public void Edit(Vacation editVacation)
        {
            foreach (Vacation vacation in _vacations)
            {
                if (editVacation.Id.Equals(vacation.Id))
                {
                    vacation.StartDate = editVacation.StartDate;
                    vacation.EndDate = editVacation.EndDate;
                    vacation.Reason = editVacation.Reason;
                    vacation.Doctor = editVacation.Doctor;
                }
            }

            Write();
        }

        public void Delete(int id)
        {
            for (int i = _vacations.Count - 1; i >= 0; i--)
            {
                if (_vacations[i].Id.Equals(id))
                {
                    _vacations.Remove(_vacations[i]);
                }
            }

            Write();
        }

        public void Write()
        {
            _serializer.Write(_vacations);
        }
    }
}