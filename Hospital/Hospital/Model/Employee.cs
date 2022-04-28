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
    }
}