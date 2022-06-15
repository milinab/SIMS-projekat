using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class EmployeeController
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        public Employee ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Employee newEmployee)
        {
            _service.Create(newEmployee);
        }

        public void Edit(Employee editEmployee)
        {
            _service.Edit(editEmployee);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<Employee> Read()
        {
            return _service.Read();
        }
    }
}
