using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.ReferralRepo
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly Serializer<Referral> _serializer;

        public ReferralRepository()
        {
            _serializer = new Serializer<Referral>("referrals.csv");
        }
        
        public List<Referral> Read()
        {
            return _serializer.Read().ToList();
        }

        public Referral ReadById(int id)
        {
            return Read().FirstOrDefault(referral => referral.Id == id);
        }

        public void Create(Referral newReferral)
        {
            var list = Read();
            list.Add(newReferral);
            Write(list);
        }

        public void Edit(Referral editReferral)
        {
            var list = Read();
            foreach (var referral in list.Where(referral => editReferral.Id == referral.Id))
            {
                referral.Reason = editReferral.Reason;
                referral.Specialization = editReferral.Specialization;
                referral.DoctorId = editReferral.DoctorId;
                referral.PatientId = editReferral.PatientId;
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

        public void Write(List<Referral> list)
        {
            _serializer.Write(list);
        }
    }
}