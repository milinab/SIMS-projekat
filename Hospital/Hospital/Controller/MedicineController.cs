using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class MedicineController
    {
        private readonly MedicineService _service;

        public MedicineController(MedicineService service)
        {
            _service = service;
        }

        public Medicine ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Medicine newMedicine)
        {
            _service.Create(newMedicine);
        }

        public void Edit(Medicine editMedicine)
        {
            _service.Edit(editMedicine);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }
        public ObservableCollection<Medicine>Read()
        {
            return _service.Read();
        }
    }
}
