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
    public class MedicineReplaceController
    {
        private readonly MedicineReplaceService _service;

        public MedicineReplaceController(MedicineReplaceService service)
        {
            _service = service;
        }

        public ReplacementMedicine ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(ReplacementMedicine newMedicineReplace)
        {
            _service.Create(newMedicineReplace);
        }

        public void Edit(ReplacementMedicine editMedicineReplace)
        {
            _service.Edit(editMedicineReplace);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<ReplacementMedicine>Read()
        {
            return _service.Read();
        }
    }
}
