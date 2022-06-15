using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.AllergenRepository;

namespace Hospital.Repository.AllergenRepos
{
    public class AllergenRepository : IAllergenRepository
    {
        private List<Allergen> _allergens;
        private readonly Serializer<Allergen> _serializer;

        public AllergenRepository()
        {
            _serializer = new Serializer<Allergen>("allergens.csv");
            _allergens = new List<Allergen>();
        }

        public List<Allergen> Read()
        {
            _allergens = _serializer.Read();
            return _allergens;
        }

        public Allergen ReadById(int id)
        {
            return _allergens.FirstOrDefault(allergen => allergen.Id.Equals(id));
        }

        public void Create(Allergen newAllergen)
        {
            _allergens.Add(newAllergen);
            Write();
        }

        public void Edit(Allergen editAllergen)
        {
            foreach (var allergen in _allergens.Where(allergen => editAllergen.Id.Equals(allergen.Id)))
            {
                allergen.Name = editAllergen.Name;
            }

            Write();
        }

        public void Delete(int id)
        {
            for (int i = _allergens.Count - 1; i >= 0; i--)
            {
                if (_allergens[i].Id.Equals(id))
                {
                    _allergens.Remove(_allergens[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_allergens);
        }
    }
}
