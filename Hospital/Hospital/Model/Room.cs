using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassDiagram.Model
{

    //[Serializable()]

    public class Room //:INotifyPropertyChanged
    {
       

        private string _id;
        private string _type;
        private Equipment _eq;

        public Equipment Equipment { get; set; }


        public string Id 
        { 
            get { return _id; }
            set { _id = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Room() { }

        public Room(string id, Equipment eq, string ty)
        {
            _id = id;
            Equipment = eq;
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