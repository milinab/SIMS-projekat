using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string QuestionText { get; set; }
        [DataMember]
        public int Grade { get; set; }
        [DataMember]
        public int SurveyId { get; set; }



        public Question()
        {
        }

        public Question(string question, int grade, int surveyId)
        {
            QuestionText = question;
            Grade = grade;
            SurveyId = surveyId;
        }

    }
}