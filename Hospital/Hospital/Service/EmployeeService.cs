using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class EmployeeService
    {
        private int _id;
        public readonly EmployeeRepository _repository;
        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _repository = employeeRepository;
            ObservableCollection<Employee> employees = Read();
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

        public ObservableCollection<Employee> Read()
        {
            return _repository.Read();
        }
    }
}