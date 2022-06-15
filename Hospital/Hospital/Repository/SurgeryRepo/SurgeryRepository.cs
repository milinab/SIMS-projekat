using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.SurgeryRepo
{
    public class SurgeryRepository : ISurgeryRepository
    {
        private readonly Serializer<Surgery> _serializer;

        public SurgeryRepository()
        {
            _serializer = new Serializer<Surgery>("surgeries.csv");
        }

        public List<Surgery> Read()
        {
            return _serializer.Read();
        }

        public Surgery ReadById(int id)
        {
            foreach (Surgery surgery in Read())
            {
                if (surgery.Id.Equals(id))
                {
                    return surgery;
                }
            }
            return null;
        }

        public void Create(Surgery newSurgery)
        {
            var list = Read();
            list.Add(newSurgery);
            Write(list);
        }

        public void Edit(Surgery editSurgery)
        {
            var list = Read();
            foreach (Surgery surgery in list)
            {
                if (editSurgery.Id.Equals(surgery.Id))
                {
                    surgery.Date = editSurgery.Date;
                    surgery.Duration = editSurgery.Duration;
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

        public void Write(List<Surgery> list)
        {
            _serializer.Write(list);
        }
    }
}
