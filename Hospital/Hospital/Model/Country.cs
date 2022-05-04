using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Country
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public Country()
        {
        }

        public Country(string name)
        {
            Name = name;
        }

        public Country(string name,int id)
        {
            Name = name;
            Id = id;
        }
    }
}