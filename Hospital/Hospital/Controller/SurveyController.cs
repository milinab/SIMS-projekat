using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class SurveyController
    {
        private readonly SurveyService _service;

        public SurveyController(SurveyService service)
        {
            _service = service;
        }

        public Survey ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Survey newSurvey)
        {
            _service.Create(newSurvey);
        }

        public void Edit(Survey editSurvey)
        {
            _service.Edit(editSurvey);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<Survey> Read()
        {
            return _service.Read();
        }

        public List<Survey> GetAllByType()
        {
            return _service.Read();
        }
    }
}
