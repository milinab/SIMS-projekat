using System;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Guest
    {
        [DataMember]
        public int Id { get; set; }

        public Guest()
        {
        }
    }
}