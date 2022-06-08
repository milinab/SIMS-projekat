using System.Collections.Generic;
using Hospital.Repository;
using System.Linq;
using Hospital.Model;

namespace Hospital.Service
{
    public class EmployeeService
    {
        private int _id;
        private readonly EmployeeRepository _repository;
        
        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _repository = employeeRepository;
            List<Employee> employees = Read();
            if (employees.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = employees.Last().Id;
            }
        }
        public Employee ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Employee newEmployee)
        {
            newEmployee.Id = GenerateId();
            _repository.Create(newEmployee);
        }

        public void Edit(Employee editEmployee)
        {
            _repository.Edit(editEmployee);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Employee> Read()
        {
            return _repository.Read();
        }
        
        private int GenerateId()
        {
            return ++_id;
        }
    }
}