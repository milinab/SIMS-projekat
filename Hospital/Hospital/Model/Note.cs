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
        [DataMember]
        public DateTime NotificationDate { get; set; }

        public Note()
        {
        }

        public Note(string name)
        {
            Name = name;
        }

        public Note(string name,int id, string noteText, DateTime date)
        {
            Name = name;
            Id = id;
            NoteText = noteText;
            Date = date;

        }
        public Note(string name, string noteText, DateTime date, DateTime notificationDate)
        {
            Name = name;
            NoteText = noteText;
            Date = date;
            NotificationDate = notificationDate;

        }

        public Note(string name, int id, string noteText)
        {
            Name = name;
            Id = id;
            NoteText = noteText;
            

        }
    }
}