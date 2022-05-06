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

        public Question()
        {
        }

        public Question(string question, int grade)
        {
            QuestionText = question;
            Grade = grade;
        }

    }
}