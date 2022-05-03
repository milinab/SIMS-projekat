using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;



namespace Hospital.Model
{
    [CollectionDataContract]
    public class AllergenList : List<int> { }
   
}
