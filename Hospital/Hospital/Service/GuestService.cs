using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class GuestService
    {
        private int _id;
        public readonly GuestRepository _guestRepository;

        private readonly ObservableCollection<Guest> _guests;

        public GuestService(GuestRepository guestRepository)
        {
            _guestRepository = new GuestRepository();
            _guests = _guestRepository.Read();
            if (_guests.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = _guests.Last().Id;
            }
            _guestRepository = guestRepository;
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
            newGuest.Id = GenerateID();
            _guests.Add(newGuest);
            Console.WriteLine(_guests.Last().Id);
        }

        public void Edit(Guest editGuest)
        {
            foreach (Guest guest in _guests)
            {
                if (guest.Id.Equals(editGuest.Id))
                {
                    //guest.Name = editGuest.Name;
                    //guest.LastName = editGuest.LastName;

                }
            }
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
        }

        public ObservableCollection<Guest> ReadAll()
        {
            return _guests;
        }
        private int GenerateID()
        {
            return ++_id;
        }
    }
}
