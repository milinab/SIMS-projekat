using System;
using System.ComponentModel;

namespace Hospital.Model
{
   public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
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
   
   }
}