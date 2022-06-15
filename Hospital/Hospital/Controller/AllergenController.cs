using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class AllergenController
    {
        private readonly AllergenService _service;

        public AllergenController(AllergenService service)
        {
            _service = service;
        }

        public Allergen ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Allergen newAllergen)
        {
            _service.Create(newAllergen);
        }

        public void Edit(Allergen editAllergen)
        {
            _service.Edit(editAllergen);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<Allergen> Read()
        {
            return _service.Read();
        }

        public List<Allergen> ReadByIds(List<int> alergenIds) {

            return _service.ReadByIds(alergenIds);

        }
    }
}
