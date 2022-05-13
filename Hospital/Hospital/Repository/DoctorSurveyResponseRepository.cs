using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class DoctorSurveyResponseRepository
    {
        private ObservableCollection<DoctorSurveyResponse> _doctorSurveyResponse;
        private readonly Serializer<DoctorSurveyResponse> _serializer;
        private readonly DoctorSurveyResponseRepository _doctorSurveyResponseRepository;

        public DoctorSurveyResponseRepository()
        {
            _serializer = new Serializer<DoctorSurveyResponse>("doctorSurveyResponses.csv");
            _doctorSurveyResponse = new ObservableCollection<DoctorSurveyResponse>();
        } 

        public DoctorSurveyResponseRepository(DoctorSurveyResponseRepository doctorSurveyResponseRepository)
        {
            _serializer = new Serializer<DoctorSurveyResponse>("doctorSurveyResponses.csv");
            _doctorSurveyResponse = new ObservableCollection<DoctorSurveyResponse>();
            _doctorSurveyResponseRepository = doctorSurveyResponseRepository;
        }
        public ObservableCollection<DoctorSurveyResponse> Read()
        {
            _doctorSurveyResponse = _serializer.Read();
            return _doctorSurveyResponse;
        }

        public DoctorSurveyResponse ReadById(int id)
        {
            foreach (DoctorSurveyResponse doctorSurveyResponse in _doctorSurveyResponse)
            {
                if (doctorSurveyResponse.Id.Equals(id))
                {
                    return doctorSurveyResponse;
                }
            }
            return null;
        }

        public void Create(DoctorSurveyResponse newDoctorSurveyResponse)
        {
            _doctorSurveyResponse.Add(newDoctorSurveyResponse);
            Write();
        }

        public void Edit(DoctorSurveyResponse editDoctorSurveyResponse)
        {
            foreach (DoctorSurveyResponse doctorSurveyResponse in _doctorSurveyResponse)
            {
                if (editDoctorSurveyResponse.Id.Equals(doctorSurveyResponse.Id))
                {
                    //
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _doctorSurveyResponse.Count - 1; i >= 0; i--)
            {
                if (_doctorSurveyResponse[i].Id.Equals(id))
                {
                    _doctorSurveyResponse.Remove(_doctorSurveyResponse[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_doctorSurveyResponse);
        }
    }
}
