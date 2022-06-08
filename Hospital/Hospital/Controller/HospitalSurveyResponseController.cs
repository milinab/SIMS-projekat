using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class HospitalSurveyResponseController
    {
        private readonly HospitalSurveyResponseService _service;

        public HospitalSurveyResponseController(HospitalSurveyResponseService service)
        {
            _service = service;
        }

        public HospitalSurveyResponse ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(HospitalSurveyResponse newHospitalSurveyResponse)
        {
            _service.Create(newHospitalSurveyResponse);
        }

        public void Edit(HospitalSurveyResponse editHospitalSurveyResponse)
        {
            _service.Edit(editHospitalSurveyResponse);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<HospitalSurveyResponse> Read()
        {
            return _service.Read();
        }
    }
}
