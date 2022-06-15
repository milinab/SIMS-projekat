using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.AllergenRepository;

namespace Hospital.Service
{
    public class AllergenService
    {
        private int _id;
        private readonly IAllergenRepository _repository;

        public AllergenService(IAllergenRepository allergenRepository)
        {
            _repository = allergenRepository;
            List<Allergen> allergens = Read();
            if (allergens.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = allergens.Last().Id;
            }
        }

        public Allergen ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Allergen newAllergen)
        {
            newAllergen.Id = GenerateId();
            _repository.Create(newAllergen);
        }

        public void Edit(Allergen editAllergen)
        {
            _repository.Edit(editAllergen);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Allergen> Read()
        {
            return _repository.Read();
        }

        public List<Allergen> ReadByIds(List<int> ids)
        {
            List<Allergen> ret = new List<Allergen>();
            foreach (int al in ids) {
                ret.Add(_repository.ReadById(al));
            }
            return ret;
        }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}
