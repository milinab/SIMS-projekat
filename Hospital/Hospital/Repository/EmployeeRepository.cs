using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.Repository
{
    public class EmployeeRepository
    {
        private ObservableCollection<Employee> _employees;
        private readonly Serializer<Employee> _serializer;

        public EmployeeRepository()
        {
            _serializer = new Serializer<Employee>("employees.csv");
            _employees = new ObservableCollection<Employee>();
        }

        public ObservableCollection<Employee> Read()
        {
            _employees = _serializer.Read();
            return _employees;
        }

        public Employee ReadById(int id)
        {
            foreach (Employee employee in _employees)
            {
                if (employee.Id.Equals(id))
                {
                    return employee;
                }
            }
            return null;
        }

        public void Create(Employee newEmployee)
        {
            _employees.Add(newEmployee);
            Write();
        }

        public void Edit(Employee editEmployee)
        {
            foreach (Employee employee in _employees)
            {
                if (editEmployee.Id.Equals(employee.Id))
                {
                    employee.IdNumber = editEmployee.IdNumber;
                    employee.Name = editEmployee.Name;
                    employee.LastName = editEmployee.LastName;
                    employee.Password = editEmployee.Password;
                    employee.Username = editEmployee.Username;
                    employee.Phone = editEmployee.Phone;
                    employee.Address = editEmployee.Address;
                    employee.DateOfBirth = editEmployee.DateOfBirth;
                    employee.Email = editEmployee.Email;
                    employee.Vacation = editEmployee.Vacation;
                    employee.Experience = editEmployee.Experience;
                    employee.DateOfEmployment = editEmployee.DateOfEmployment;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _employees.Count - 1; i >= 0; i--)
            {
                if (_employees[i].Id.Equals(id))
                {
                    _employees.Remove(_employees[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_employees);
        }
    }
}
