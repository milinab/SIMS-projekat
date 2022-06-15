using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.TherapyRepo
{
    public interface ITherapyRepository : IRepositoryBase<Therapy,int>
    {
        List<Therapy> ReadByPatientId(int id);
    }
}
