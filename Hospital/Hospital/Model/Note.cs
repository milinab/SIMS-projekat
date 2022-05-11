using System.Runtime.Serialization;
using System;

namespace Hospital.Model
{
    [DataContract]
    public class Note
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string NoteText { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

        public Note()
        {
        }

        public Note(string name)
        {
            Name = name;
        }

        public Note(string name,int id, string NoteText, DateTime date)
        {
            Name = name;
            Id = id;
            NoteText = NoteText;
            Date = date;

        }
    }
}