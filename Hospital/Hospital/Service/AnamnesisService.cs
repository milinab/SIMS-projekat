using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class AnamnesisService
    {
        private int _id;
        private readonly AnamnesisRepository _repository;

        public AnamnesisService(AnamnesisRepository anamnesisRepository)
        {
            _repository = anamnesisRepository;
            List<Anamnesis> anamnesis = Read();
            _id = anamnesis.Count == 0 ? 0 : anamnesis.Last().Id;
        }
        
        private int GenerateId()
        {
            return ++_id;
        }
        
        public List<Anamnesis> Read()
        {
            return _repository.Read();
        }
        
        public Anamnesis ReadById(int id)
        {
            return _repository.ReadById(id);
        }
        
        public void Create(Anamnesis newAnamnesis)
        {
            newAnamnesis.Id = GenerateId();
            _repository.Create(newAnamnesis);
        }
        
        public void Edit(Anamnesis editAnamnesis)
        {
            _repository.Edit(editAnamnesis);
        }
        
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        
        public void Write()
        {
            _repository.Write();
        }

        public Anamnesis ReadByAppointmentId(int appointmentId)
        {
            return _repository.ReadByAppointmentId(appointmentId);
        }
    }
}