using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class SurgeryController
    {
        private readonly SurgeryService _service;

        public SurgeryController(SurgeryService service)
        {
            _service = service;
        }

        public Surgery ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Surgery newSurgery)
        {
            _service.Create(newSurgery);
        }

        public void Edit(Surgery editSurgery)
        {
            _service.Edit(editSurgery);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<Surgery> Read()
        {
            return _service.Read();
        }
    }
}