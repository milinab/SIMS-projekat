using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class MedicineService
    {
        private int _id;
        private readonly MedicineRepository _repository;

        public MedicineService(MedicineRepository medicineRepository)
        {
            _repository = medicineRepository;
            ObservableCollection<Medicine> medicine = Read();
            if(medicine != null)
                _id = int.Parse(medicine.Last().Id);
            else
                _id = 0;
        }

        public Medicine ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Medicine newMedicine)
        {
            newMedicine.Id = GenerateId().ToString();
            _repository.Create(newMedicine);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public void Edit(Medicine editMedicine)
        {
            _repository.Edit(editMedicine);
        }
        public ObservableCollection<Medicine>Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }

    }   
      

}
