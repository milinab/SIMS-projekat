using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository.GuestRepo
{
    public class GuestRepository : IGuestRepository
    {
        private List<Guest> _guests;
        private readonly Serializer<Guest> _serializer;

        public GuestRepository()
        {
            _serializer = new Serializer<Guest>("guests.csv");
            _guests = new List<Guest>();
        }

        public List<Guest> Read()
        {
            _guests = _serializer.Read();
            return _guests;
        }

        public Guest ReadById(int id)
        {
            foreach (Guest guest in _guests)
            {
                if (guest.Id.Equals(id))
                {
                    return guest;
                }
            }
            return null;
        }

        public void Create(Guest newGuest)
        {
            _guests.Add(newGuest);
            Write();
        }

        public void Edit(Guest editGuest)
        {
            foreach (Guest guest in _guests)
            {
                if (editGuest.Id.Equals(guest.Id))
                {
                    //guest.Name = editGuest.Name;
                    //guest.LastName = editGuest.LastName;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _guests.Count - 1; i >= 0; i--)
            {
                if (_guests[i].Id.Equals(id))
                {
                    _guests.Remove(_guests[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_guests);
        }
    }
}
