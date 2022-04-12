using Hospital.Model;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassDiagram.Model
{

    [Serializable()]

    public class Room //:INotifyPropertyChanged
    {
       

        private string _id;
        private string _name;

        public string Id 
        { 
            get { return _id; }
            set { _id = value; }
        }

        public string Equipment
        {
            get { return _name; }
            set { _name = value; }
        }

        public Room() { }

        public Room(string id = "No id",
            string equipment = "No equipment")
        {
            Id = id;
            Equipment = equipment;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        { 
            info.AddValue("Id", Id);
            info.AddValue("Equipment", Equipment);
        }

        // The deserialize function (Removes Object Data from File)
        public Room(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the properties
            Id = (string)info.GetValue("Id", typeof(string));
            Equipment = (string)info.GetValue("Equipment", typeof(string));

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