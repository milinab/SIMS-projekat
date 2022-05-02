using System;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Employee : User
    {
        [DataMember]
        public int Vacation { get; set; }
        [DataMember]
        public int Experience { get; set; }
        [DataMember]
        public DateTime DateOfEmployment { get; set; }

        public Employee()
        {
        }
        
        public Employee(Employee employee)
        {
            Vacation = employee.Vacation;
            Experience = employee.Experience;
            DateOfEmployment = employee.DateOfEmployment;
        }

        public Employee(User user, int vacation, int experience, DateTime dateOfEmployment) : base(user)
        {
            Vacation = vacation;
            Experience = experience;
            DateOfEmployment = dateOfEmployment;
        }
    }
}