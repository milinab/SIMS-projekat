using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class AllergenService
    {
        private int _id;
        private readonly AllergenRepository _repository;

        public AllergenService(AllergenRepository allergenRepository)
        {
            _repository = allergenRepository;
            ObservableCollection<Allergen> allergens = Read();
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

        public ObservableCollection<Allergen> Read()
        {
            return _repository.Read();
        }

        public ObservableCollection<Allergen> ReadByIds(List<int> ids)
        {
            ObservableCollection<Allergen> ret = new ObservableCollection<Allergen>();
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
