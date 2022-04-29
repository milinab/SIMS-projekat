using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class ManagerController
    {
        private readonly ManagerService _service;

        public ManagerController(ManagerService service)
        {
            _service = service;
        }

        public Manager ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Manager newManager)
        {
            _service.Create(newManager);
        }

        public void Edit(Manager editManager)
        {
            _service.Edit(editManager);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<Manager> Read()
        {
            return _service.Read();
        }
    }
}