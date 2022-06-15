using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.HospitalSurveyResponseRepo
{
    public class HospitalSurveyResponseRepository : IHospitalSurveyResponseRepository
    {
        private readonly Serializer<HospitalSurveyResponse> _serializer;

        public HospitalSurveyResponseRepository()
        {
            _serializer = new Serializer<HospitalSurveyResponse>("hospitalSurveyResponses.csv");
        } 

        public List<HospitalSurveyResponse> Read()
        {
            return _serializer.Read();
        }

        public HospitalSurveyResponse ReadById(int id)
        {
            foreach (HospitalSurveyResponse hospitalSurveyResponse in Read())
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
            var list = Read();
            list.Add(newHospitalSurveyResponse);
            Write(list);
        }

        public void Edit(HospitalSurveyResponse editHospitalSurveyResponse)
        {
            var list = Read();
            foreach (HospitalSurveyResponse hospitalSurveyResponse in list)
            {
                if (editHospitalSurveyResponse.Id.Equals(hospitalSurveyResponse.Id))
                {
                }
            }
            Write(list);
        }

        public void Delete(int id)
        {
            var list = Read();
            foreach (var resp in list.Where(resp => resp.Id == id))
            {
                list.Remove(resp);
            }
            Write(list);
        }

        public void Write(List<HospitalSurveyResponse> list)
        {
            _serializer.Write(list);
        }
    }
}
