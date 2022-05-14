using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital.View.PatientView.Validations
{
    class NoEmptyInputsRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            var input = value as string;

            if (input.Length != 0)
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Necessary to input");
            }




        }
    }
}
