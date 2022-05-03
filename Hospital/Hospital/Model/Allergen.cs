using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Allergen
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
       
        public Allergen()
        {
        }

        public Allergen(string name)
        {
            Name = name;
        }
    }
}