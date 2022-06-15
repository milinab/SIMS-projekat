using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.AppointmentRepo;
using Hospital.Repository.TherapyRepo;

namespace Hospital.Repository.AnamnesisRepo
{
    public class AnamnesisRepository : IAnamnesisRepository
    {
        private List<Anamnesis> _anamnesis;
        private readonly Serializer<Anamnesis> _serializer;
        private readonly TherapyRepository _therapyRepository;
        private readonly AppointmentRepository _appointmentRepository;

        public AnamnesisRepository(TherapyRepository therapyRepository, AppointmentRepository appointmentRepository)
        {
            _serializer = new Serializer<Anamnesis>("anamnesis.csv");
            _anamnesis = new List<Anamnesis>();
            _therapyRepository = therapyRepository;
            _appointmentRepository = appointmentRepository;
        }

        public List<Anamnesis> Read()
        {
            _anamnesis = _serializer.Read().ToList();
            foreach (var anamnesis in _anamnesis)
            {
                var therapy = _therapyRepository.ReadById(anamnesis.TherapyId);
                var appointment = _appointmentRepository.ReadById(anamnesis.AppointmentId);
                if (therapy == null || appointment == null) continue;
                anamnesis.Therapy = therapy;
                anamnesis.Appointment = appointment;
            }
            return _anamnesis;
        }
        
        public Anamnesis ReadById(int id)
        {
            _anamnesis = _serializer.Read().ToList();
            foreach (var anamnesis in _anamnesis)
            {
                if (anamnesis.Id != id) continue;
                var therapy = _therapyRepository.ReadById(anamnesis.TherapyId);
                var appointment = _appointmentRepository.ReadById(anamnesis.AppointmentId);
                if (therapy == null || appointment == null) continue;
                anamnesis.Therapy = therapy;
                anamnesis.Appointment = appointment;
                return anamnesis;
            }
            return null;
        }
        
        public void Create(Anamnesis newAnamnesis)
        {
            _anamnesis.Add(newAnamnesis);
            Write();
        }
        
        public void Edit(Anamnesis editAnamnesis)
        {
            foreach (var anamnesis in _anamnesis.Where(anamnesis => editAnamnesis.Id.Equals(anamnesis.Id)))
            {
                anamnesis.Diagnosis = editAnamnesis.Diagnosis;
                anamnesis.Referral = editAnamnesis.Referral;
                anamnesis.Therapy = editAnamnesis.Therapy;
            }

            Write();
        }
        
        public void Delete(int id)
        {
            for (int i = _anamnesis.Count - 1; i >= 0; i--)
            {
                if (_anamnesis[i].Id.Equals(id))
                {
                    _anamnesis.Remove(_anamnesis[i]);
                }
            }
            Write();
        }
        
        public void Write()
        {
            _serializer.Write(_anamnesis);
        }
        public Anamnesis ReadByAppointmentId(int appointmentId)
        {
            _anamnesis = _serializer.Read().ToList();
            foreach (Anamnesis anamnesis in _anamnesis)
            {
                if (anamnesis.AppointmentId == appointmentId)
                {
                    Appointment appointment = _appointmentRepository.ReadById(anamnesis.AppointmentId);
                    Therapy therapy = _therapyRepository.ReadById(anamnesis.TherapyId);

                    if (appointment != null)
                    {
                        anamnesis.Appointment = appointment;
                    }
                    if (therapy != null)
                    {
                        anamnesis.Therapy = therapy;
                    }

                    return anamnesis;
                   
                }
            }

            return null;
            
        }
    }
}