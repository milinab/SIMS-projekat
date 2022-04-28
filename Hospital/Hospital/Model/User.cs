using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Hospital.Repository;

namespace Hospital.Model
{
    [DataContract]
    public class User : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _lastName;
        private string _idNumber;
        private string _username;
        private string _password;
        private Address _address;
        private string _phone;
        private string _email;
        private string _accountType;
        private DateTime _dateOfBirth;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        [DataMember]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        [DataMember]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName= value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        [DataMember]
        public string IdNumber
        {
            get
            {
                return _idNumber;
            }
            set
            {
                if (value != _idNumber)
                {
                    _idNumber = value;
                    OnPropertyChanged("IdNumber");
                }
            }
        }
        [DataMember]
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }
        [DataMember]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        [DataMember]
        public int AddressId { get; set; }
        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        [DataMember]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        [DataMember]
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        [DataMember]
        public string AccountType
        {
            get
            {
                return _accountType;
            }
            set
            {
                if (value != _accountType)
                {
                    _accountType = value;
                    OnPropertyChanged("AccountType");
                }
            }
        }
        [DataMember]
        public DateTime DateOfBirth

        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value != _dateOfBirth)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
    }
}