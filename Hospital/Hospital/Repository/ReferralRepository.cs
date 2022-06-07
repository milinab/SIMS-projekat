using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository
{
    public class ReferralRepository
    {
        private List<Referral> _referrals;
        private readonly Serializer<Referral> _serializer;

        public ReferralRepository()
        {
            _serializer = new Serializer<Referral>("referrals.csv");
            _referrals = new List<Referral>();
        }
        
        public List<Referral> Read()
        {
            _referrals = _serializer.Read().ToList();
            return _referrals;
        }

        public Referral ReadById(int id)
        {
            return _referrals.FirstOrDefault(referral => referral.Id == id);
        }

        public void Create(Referral newReferral)
        {
            _referrals.Add(newReferral);
            Write();
        }

        public void Edit(Referral editReferral)
        {
            foreach (var referral in _referrals.Where(referral => editReferral.Id == referral.Id))
            {
                referral.Reason = editReferral.Reason;
                referral.Specialization = editReferral.Specialization;
                referral.DoctorId = editReferral.DoctorId;
                referral.PatientId = editReferral.PatientId;
            }
            Write();
        }

        public void Delete(int id)
        {
            foreach (var referral in _referrals.Where(referral => referral.Id == id))
            {
                _referrals.Remove(referral);
            }
            Write();
        }

        public void Write()
        {
            var collection = new ObservableCollection<Referral>(_referrals);
            _serializer.Write(collection);
        }
    }
}