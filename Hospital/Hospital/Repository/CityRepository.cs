using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class CityRepository
    {
        private ObservableCollection<City> _cities;
        private readonly Serializer<City> _serializer;

        public CityRepository()
        {
            _serializer = new Serializer<City>("cities.csv");
            _cities = new ObservableCollection<City>();
        }

        public ObservableCollection<City> Read()
        {
            _cities = _serializer.Read();
            return _cities;
        }

        public City ReadById(int id)
        {
            foreach (City city in _cities)
            {
                if (city.Id.Equals(id))
                {
                    return city;
                }
            }
            return null;
        }

        public void Create(City newCity)
        {
            _cities.Add(newCity);
            Write();
        }

        public void Edit(City editCity)
        {
            foreach (City city in _cities)
            {
                if (editCity.Id.Equals(city.Id))
                {
                    city.Country = editCity.Country;
                    city.Name = editCity.Name;
                    city.Zip = editCity.Zip;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _cities.Count - 1; i >= 0; i--)
            {
                if (_cities[i].Id.Equals(id))
                {
                    _cities.Remove(_cities[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_cities);
        }
    }
}
