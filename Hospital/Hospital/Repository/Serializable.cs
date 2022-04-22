using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository {
    public interface Serializable: INotifyPropertyChanged {

        string[] ToCSV();

        void FromCSV(string[] values);
    }
}
