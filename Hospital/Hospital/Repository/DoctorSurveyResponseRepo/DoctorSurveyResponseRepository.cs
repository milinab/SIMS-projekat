using System.Collections.Generic;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.DoctorSurveyResponseRepo
{
    public class DoctorSurveyResponseRepository : IDoctorSurveyResponseRepository
    {
        private readonly Serializer<DoctorSurveyResponse> _serializer;

        public DoctorSurveyResponseRepository()
        {
            _serializer = new Serializer<DoctorSurveyResponse>("doctorSurveyResponses.csv");
        } 

        public List<DoctorSurveyResponse> Read()
        {
            return _serializer.Read();
        }

        public DoctorSurveyResponse ReadById(int id)
        {
            foreach (DoctorSurveyResponse doctorSurveyResponse in Read())
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
            var list = Read();
            list.Add(newDoctorSurveyResponse);
            Write(list);
        }

        public void Edit(DoctorSurveyResponse editDoctorSurveyResponse)
        {
            var list = Read();
            foreach (DoctorSurveyResponse doctorSurveyResponse in list)
            {
                if (editDoctorSurveyResponse.Id.Equals(doctorSurveyResponse.Id))
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

        public void Write(List<DoctorSurveyResponse> list)
        {
            _serializer.Write(list);
        }
    }
}
