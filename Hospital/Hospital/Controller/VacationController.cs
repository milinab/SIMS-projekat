using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class VacationController
    {
        private readonly VacationService _service;
        
        public VacationController(VacationService service)
        {
            _service = service;
        }
        
        public List<Vacation> Read()
        {
            return _service.Read();
        }

        public Vacation ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Vacation newVacation)
        {
            _service.Create(newVacation);
        }

        public void NoPriorityCreate(Vacation newVacation)
        {
            _service.NoPriorityCreate(newVacation);
        }

        public void Edit(Vacation editVacation)
        {
            _service.Edit(editVacation);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}