using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.GuestRepo
{
    public class GuestRepository : IGuestRepository
    {
        private readonly Serializer<Guest> _serializer;

        public GuestRepository()
        {
            _serializer = new Serializer<Guest>("guests.csv");
        }

        public List<Guest> Read()
        {
            return _serializer.Read();
        }

        public Guest ReadById(int id)
        {
            return Read().FirstOrDefault(guest => guest.Id.Equals(id));
        }

        public void Create(Guest newGuest)
        {
            var list = Read();
            list.Add(newGuest);
            Write(list);
        }

        public void Edit(Guest editGuest)
        {
            var list = Read();
            foreach (var guest in list.Where(guest => editGuest.Id.Equals(guest.Id)))
            {
                
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

        public void Write(List<Guest> list)
        {
            _serializer.Write(list);
        }
    }
}
