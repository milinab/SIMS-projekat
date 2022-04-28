using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Doctor : Employee
    {
        [DataMember]
        public string Specialization { get; set; }
        public Doctor()
        {

        }

        public Doctor(string name, string lastname) {
            Name = name;
            LastName = lastname;
        }
    }
}