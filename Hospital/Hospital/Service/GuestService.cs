using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class GuestService
    {
        private int _id;
        private readonly GuestRepository _repository;

        public GuestService(GuestRepository guestRepository)
        {
            _repository = guestRepository;
            ObservableCollection<Guest> guests = Read();
            if (guests.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = guests.Last().Id;
            }
        }

        public Guest ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Guest newGuest)
        {
            newGuest.Id = GenerateId();
            _repository.Create(newGuest);
        }

        public void Edit(Guest editGuest)
        {
            _repository.Edit(editGuest);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ObservableCollection<Guest> Read()
        {
            return _repository.Read();
        }
        private int GenerateId()
        {
            return ++_id;
        }
    }
}
