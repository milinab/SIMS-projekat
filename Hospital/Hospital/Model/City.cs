using System;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class City
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public City()
        {
        }
    }
}