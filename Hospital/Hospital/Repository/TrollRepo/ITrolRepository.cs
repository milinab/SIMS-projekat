using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.TrollRepo
{
    public interface ITrolRepository : IRepositoryBase<Trol,int>
    {
        Trol ReadByPatientId(int id);
    }
}
