using System.Collections.Generic;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Serializer<Employee> _serializer;

        public EmployeeRepository()
        {
            _serializer = new Serializer<Employee>("employees.csv");
        }

        public List<Employee> Read()
        {
            return _serializer.Read();
        }

        public Employee ReadById(int id)
        {
            return Read().FirstOrDefault(employee => employee.Id.Equals(id));
        }

        public void Create(Employee newEmployee)
        {
            var list = Read();
            list.Add(newEmployee);
            Write(list);
        }

        public void Edit(Employee editEmployee)
        {
            var list = Read();
            foreach (var employee in list.Where(employee => editEmployee.Id.Equals(employee.Id)))
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
            Write(list);
        }

        public void Delete(int id)
        {
            var list = Read();
            foreach (var resp in list.Where(resp => resp.Id == id))
            {
                list.Remove(resp);
            }
            Write(list);
        }

        public void Write(List<Employee> list)
        {
            _serializer.Write(list);
        }
    }
}
