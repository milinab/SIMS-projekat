using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Hospital.Model;

namespace Hospital.View.PatientView.ViewModel
{
    internal class TherapyShowViewModel
    {
        private readonly Therapy _therapy;
        public string TherapySubject => _therapy.Medicine + " " + _therapy.Time + "\n " + _therapy.TherapyText;
        public string Medicine => _therapy.Medicine;
        public DateTime Time => _therapy.Time;
        public string TherapyText => _therapy.TherapyText;

        public DateTime Date => _therapy.Time;

        public DateTime End => _therapy.Time + TimeSpan.FromMinutes(30);

        public TherapyShowViewModel()
        {
        }

        public TherapyShowViewModel(Therapy therapy)
        {
            _therapy = therapy;
        }
    }
}
