using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class TrolController
    {
        private readonly TrolService _service;

        public TrolController(TrolService service)
        {
            _service = service;
        }

        public Trol ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Trol newTrol)
        {
            _service.Create(newTrol);
        }

        public void Edit(Trol editTrol)
        {
            _service.Edit(editTrol);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<Trol> Read()
        {
            return _service.Read();
        }
        public Trol ReadByPatientId(int patientId)
        {
            return _service.ReadByPatientId(patientId);
        }
    }
}
