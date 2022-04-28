using System;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public int CityId { get; set; }
        public City City { get; set; }

}
}