using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Equipment
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int _id;
        private string _number;
        private string _name;
        private string _room;

        [DataMember]
        public int Id
        {
            get { return _id; }
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
        public string Room
        {
            get { return _room; }
            set { 
                if(value!= _room)
                {
                    _room = value;
                    OnPropertyChanged("Room");
                }
            }
        }
        [DataMember]
        public string Number
        {
            get { return _number; }
            set
            {
                if (value != _number)
                {
                    _number = value;
                    OnPropertyChanged("Number");
                }
            }
        }
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public Equipment()
        {

        }
        public Equipment(int id, string num, string name)
        {
            Id = id;
            Number = num;
            Name = name;
        }
        public Equipment(int id, string num, string name, string room)
        {
            Id = id;
            Number = num;
            Name = name;
            Room = room;
        }
    }
}