using System;
using System.Collections.Generic;

namespace Hospital.Model
{
   public class Doctor : Employee
   {
        public List<string> Specialization;
        public Doctor()
        {
           
        }

        public Doctor(string name, string lastname) {
            Name = name;
            LastName = lastname;
        }

   }
}