using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class DoctorSurveyResponseController
    {
        private readonly DoctorSurveyResponseService _service;

        public DoctorSurveyResponseController(DoctorSurveyResponseService service)
        {
            _service = service;
        }

        public DoctorSurveyResponse ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(DoctorSurveyResponse newDoctorSurveyResponse)
        {
            _service.Create(newDoctorSurveyResponse);
        }

        public void Edit(DoctorSurveyResponse editDoctorSurveyResponse)
        {
            _service.Edit(editDoctorSurveyResponse);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<DoctorSurveyResponse> Read()
        {
            return _service.Read();
        }
    }
}
