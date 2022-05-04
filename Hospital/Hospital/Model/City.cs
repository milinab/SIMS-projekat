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

        public City(Country country)
        {
            this.Country = country;
        }

        public City(string name, string zip, Country country)
        {
            Name = name;
            Zip = zip;
            Country = country;
            CountryId = country.Id;
        }
        public City(string name, string zip, Country country,int id)
        {
            Name = name;
            Zip = zip;
            Country = country;
            CountryId = country.Id;
            Id = id;
        }
    }
}