using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class AllergenRepository
    {
        private ObservableCollection<Allergen> _allergens;
        private readonly Serializer<Allergen> _serializer;

        public AllergenRepository()
        {
            _serializer = new Serializer<Allergen>("allergens.csv");
            _allergens = new ObservableCollection<Allergen>();
        }

        public ObservableCollection<Allergen> Read()
        {
            _allergens = _serializer.Read();
            return _allergens;
        }

        public Allergen ReadById(int id)
        {
            foreach (Allergen Allergen in _allergens)
            {
                if (Allergen.Id.Equals(id))
                {
                    return Allergen;
                }
            }
            return null;
        }

        public void Create(Allergen newAllergen)
        {
            _allergens.Add(newAllergen);
            Write();
        }

        public void Edit(Allergen editAllergen)
        {
            foreach (Allergen Allergen in _allergens)
            {
                if (editAllergen.Id.Equals(Allergen.Id))
                {
                    Allergen.Name = editAllergen.Name;
                }
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
