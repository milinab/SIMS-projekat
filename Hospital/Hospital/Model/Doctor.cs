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
        
        public Doctor(string specialization, int vacation, int experience, DateTime dateOfEmployment, string name,
            string lastName, string idNumber, string username, string password, Address address, string phone,
            string email, string accountType, DateTime dateOfBirth)
        {
            Specialization = specialization;
            Vacation = vacation;
            Experience = experience;
            DateOfEmployment = dateOfEmployment;
            Name = name;
            LastName = lastName;
            IdNumber = idNumber;
            Username = username;
            Password = password;
            AddressId = address.Id;
            Address = address;
            Phone = phone;
            Email = email;
            AccountType = accountType;
            DateOfBirth = dateOfBirth;
        }
        
        public Doctor(User user, int vacation, int experience, DateTime dateOfEmployment, string specialization) : base(user, vacation, experience, dateOfEmployment)
        {
            Specialization = specialization;
        }
    }
}