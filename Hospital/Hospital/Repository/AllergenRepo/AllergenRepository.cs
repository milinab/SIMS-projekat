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
        }

        public List<Allergen> Read()
        {
            return _serializer.Read();
        }

        public Allergen ReadById(int id)
        {
            foreach (Allergen allergen in Read())
            {
                if (allergen.Id.Equals(id))
                {
                    return allergen;
                }
            }
            return null;
        }

        public void Create(Allergen newAllergen)
        {
            var list = Read();
            list.Add(newAllergen);
            Write(list);
        }

        public void Edit(Allergen editAllergen)
        {
            var list = Read();
            foreach (Allergen allergen in list)
            {
                if (allergen.Id.Equals(allergen.Id))
                {
                }
            }
            Write(list);
        }

        public void Delete(int id)
        {
            var list = Read();
            foreach (var resp in list.Where(resp => resp.Id == id))
            {
                list.Remove(resp);
            }
            Write(list);
        }

        public void Write(List<Allergen> list)
        {
            _serializer.Write(list);
        }
    }
}
