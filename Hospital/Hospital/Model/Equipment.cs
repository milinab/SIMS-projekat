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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _id;
        private string _number;
        private string _name;
        private string _room;

        [DataMember]
        public string Id
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
                _room = value;
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
        //[DataMember]
        //public BindingList<int> QuantityByRoom;

        //[DataMember]
        //public BindingList<Room> rooms;


        public Equipment()
        {

        }
        public Equipment(string id, string num, string name)
        {
            Id = id;
            Number = num;
            Name = name;
        }
        public Equipment(string id, string num, string name, string room)
        {
            Id = id;
            Number = num;
            Name = name;
            Room = room;
        }

        /*public Equipment(string name, string num, BindingList<int> quantityByRoom, BindingList<Room> rooms)
        {
            Name = name;
            Number = num;
            this.QuantityByRoom = quantityByRoom;
            this.rooms = rooms;
        }*/

    }
}