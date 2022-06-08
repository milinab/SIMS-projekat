using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class QuestionController
    {
        private readonly QuestionService _service;

        public QuestionController(QuestionService service)
        {
            _service = service;
        }

        public Question ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Question newQuestion)
        {
            _service.Create(newQuestion);
        }

        public void Edit(Question editQuestion)
        {
            _service.Edit(editQuestion);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<Question> Read()
        {
            return _service.Read();
        }
    }
}
