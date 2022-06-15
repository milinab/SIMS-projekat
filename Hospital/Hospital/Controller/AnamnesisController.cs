using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class AnamnesisController
    {
        private readonly AnamnesisService _service;

        public AnamnesisController(AnamnesisService service)
        {
            _service = service;
        }
        
        public List<Anamnesis> Read()
        {
            return _service.Read();
        }
        
        public Anamnesis ReadById(int id)
        {
            return _service.ReadById(id);
        }
        
        public void Create(Anamnesis newAnamnesis)
        {
            _service.Create(newAnamnesis);
        }
        
        public void Edit(Anamnesis editAnamnesis)
        {
            _service.Edit(editAnamnesis);
        }
        
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        
        public void Write(List<Anamnesis> list)
        {
            _service.Write(list);
        }
        public Anamnesis ReadByAppointmentId(int appointmentId)
        {
            return _service.ReadByAppointmentId(appointmentId);
        }
    }
}