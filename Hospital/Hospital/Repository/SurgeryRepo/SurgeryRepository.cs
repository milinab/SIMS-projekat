using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository.SurgeryRepo
{
    public class SurgeryRepository
    {
        private List<Surgery> _surgeries;
        private readonly Serializer<Surgery> _serializer;

        public SurgeryRepository()
        {
            _serializer = new Serializer<Surgery>("surgeries.csv");
            _surgeries = new List<Surgery>();
        }

        public List<Surgery> Read()
        {
            _surgeries = _serializer.Read();
            return _surgeries;
        }

        public Surgery ReadById(int id)
        {
            foreach (Surgery surgery in _surgeries)
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
            _surgeries.Add(newSurgery);
            Write();
        }

        public void Edit(Surgery editSurgery)
        {
            foreach (Surgery surgery in _surgeries)
            {
                if (editSurgery.Id.Equals(surgery.Id))
                {
                    surgery.Date = editSurgery.Date;
                    surgery.Duration = editSurgery.Duration;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _surgeries.Count - 1; i >= 0; i--)
            {
                if (_surgeries[i].Id.Equals(id))
                {
                    _surgeries.Remove(_surgeries[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_surgeries);
        }
    }
}
