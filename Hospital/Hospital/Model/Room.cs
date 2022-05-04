using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hospital.Model
{
    [DataContract]
    public class Room : INotifyPropertyChanged
    {
        private string _name;
        private string _floor;
        private int _id;
        private string _type;

        public event PropertyChangedEventHandler propertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public Equipment Equipment { get; set; }

        [DataMember]
        public int Id 
        { 
            get { return _id; }
            set { _id = value; }
        }
        
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        [DataMember]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        [DataMember]
        public string Floor
        {
            get { return _floor; }
            set { _floor = value; OnPropertyChanged("Floor"); }
        }


        [DataMember]
        public int EquipmentId { get; set; }

        public Room() { }

        public Room(string name) 
        {
            _name = name;
        }

        public Room(int id, Equipment eq, string ty)
        {
            _id = id;
            Equipment = eq;
            _type = ty;
        }

        public Room(string type, string name, Equipment equipment)
        {
            _type = type;
            Name = name;
            EquipmentId = int.Parse(equipment.Id);
            Equipment = equipment;
        }

        public Room(string name, string floor, string ty, int id)
        {
            Id = id;
            _name = name;
            _floor = floor;
            _type = ty;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        { 
            info.AddValue("Id", Id);
            info.AddValue("Equipment", Equipment);
        }

        public System.Collections.ArrayList equipment;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetEquipment()
        {
            if (equipment == null)
                equipment = new System.Collections.ArrayList();
            return equipment;
        }


        /// <pdGenerated>default setter</pdGenerated>
        public void SetEquipment(System.Collections.ArrayList newEquipment)
        {
            RemoveAllEquipment();
            foreach (Equipment oEquipment in newEquipment)
                AddEquipment(oEquipment);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddEquipment(Equipment newEquipment)
        {
            if (newEquipment == null)
                return;
            if (this.equipment == null)
                this.equipment = new System.Collections.ArrayList();
            if (!this.equipment.Contains(newEquipment))
                this.equipment.Add(newEquipment);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveEquipment(Equipment oldEquipment)
        {
            if (oldEquipment == null)
                return;
            if (this.equipment != null)
                if (this.equipment.Contains(oldEquipment))
                    this.equipment.Remove(oldEquipment);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllEquipment()
        {
            if (equipment != null)
                equipment.Clear();
        }

    }
}