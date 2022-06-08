using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class HospitalSurveyResponseRepository
    {
        private List<HospitalSurveyResponse> _hospitalSurveyResponse;
        private readonly Serializer<HospitalSurveyResponse> _serializer;

        public HospitalSurveyResponseRepository()
        {
            _serializer = new Serializer<HospitalSurveyResponse>("hospitalSurveyResponses.csv");
            _hospitalSurveyResponse = new List<HospitalSurveyResponse>();
        } 

        public List<HospitalSurveyResponse> Read()
        {
            _hospitalSurveyResponse = _serializer.Read();
            return _hospitalSurveyResponse;
        }

        public HospitalSurveyResponse ReadById(int id)
        {
            foreach (HospitalSurveyResponse hospitalSurveyResponse in _hospitalSurveyResponse)
            {
                if (hospitalSurveyResponse.Id.Equals(id))
                {
                    return hospitalSurveyResponse;
                }
            }
            return null;
        }

        public void Create(HospitalSurveyResponse newHospitalSurveyResponse)
        {
            _hospitalSurveyResponse.Add(newHospitalSurveyResponse);
            Write();
        }

        public void Edit(HospitalSurveyResponse editHospitalSurveyResponse)
        {
            foreach (HospitalSurveyResponse hospitalSurveyResponse in _hospitalSurveyResponse)
            {
                if (editHospitalSurveyResponse.Id.Equals(hospitalSurveyResponse.Id))
                {
                    //
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _hospitalSurveyResponse.Count - 1; i >= 0; i--)
            {
                if (_hospitalSurveyResponse[i].Id.Equals(id))
                {
                    _hospitalSurveyResponse.Remove(_hospitalSurveyResponse[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_hospitalSurveyResponse);
        }
    }
}
