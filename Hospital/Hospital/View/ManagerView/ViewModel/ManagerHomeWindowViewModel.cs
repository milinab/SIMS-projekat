using Hospital.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.View.ManagerView.ViewModel
{
    public class ManagerHomeWindowViewModel : ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private App _app;

        public RelayCommand FinishCommand { get; set; }

        public ManagerHomeWindowViewModel()
        {
            
        }
    }

}
