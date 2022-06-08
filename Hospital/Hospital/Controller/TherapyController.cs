using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class TherapyController
    {
        private readonly TherapyService _service;

        public TherapyController(TherapyService service)
        {
            _service = service;
        }

        public Therapy ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public List<Therapy> ReadBypatientId(int patientId)
        {
            return _service.ReadByPatientId(patientId);
        }

        public void Create(Therapy newTherapy)
        {

            _service.Create(newTherapy);
        }

        public void Edit(Therapy editTherapy)
        {
            _service.Edit(editTherapy);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<Therapy> Read()
        {
            return _service.Read();
        }
    }
}