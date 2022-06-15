using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class ReferralController
    {
        private readonly ReferralService _service;

        public ReferralController(ReferralService service)
        {
            _service = service;
        }
        
        public List<Referral> Read()
        {
            return _service.Read();
        }

        public Referral ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Referral newReferral)
        {
            _service.Create(newReferral);
        }

        public void Edit(Referral editReferral)
        {
            _service.Edit(editReferral);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public void Write(List<Referral> list)
        {
            _service.Write(list);
        }
    }
}