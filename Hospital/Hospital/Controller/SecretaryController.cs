using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class SecretaryController
    {
        private readonly SecretaryService _service;

        public SecretaryController(SecretaryService service)
        {
            _service = service;
        }

        public Secretary ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Secretary newSecretary)
        {
            _service.Create(newSecretary);
        }

        public void Edit(Secretary editSecretary)
        {
            _service.Edit(editSecretary);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<Secretary> Read()
        {
            return _service.Read();
        }
    }
}