using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.ReferralRepo;

namespace Hospital.Service
{
    public class ReferralService
    {
        private int _id;
        private readonly IReferralRepository _repository;

        public ReferralService(IReferralRepository referralRepository)
        {
            _repository = referralRepository;
            List<Referral> referrals = Read();
            _id = referrals.Count == 0 ? 0 : referrals.Last().Id;
        }
        
        public List<Referral> Read()
        {
            return _repository.Read();
        }

        public Referral ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Referral newReferral)
        {
            newReferral.Id = GenerateId();
            _repository.Create(newReferral);
        }

        public void Edit(Referral editReferral)
        {
            _repository.Edit(editReferral);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Write(List<Referral> list)
        {
            _repository.Write(list);
        }
        
        private int GenerateId()
        {
            return ++_id;
        }
    }
}