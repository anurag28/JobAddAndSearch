using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace JobSearch.Validations
{
    public class HourRule : ValidationRule
    {
        private double min;
        private double max;

        public double Min { get=>min; set=>min=value; }
        public double Max { get=>max; set=>max=value; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double hourValue=0;
            if(!double.TryParse(value.ToString(), out hourValue))
            {
                return new ValidationResult(false, "Hours entered are not in correct format");
            }

            if(hourValue<Min || hourValue > Max)
            {
                return new ValidationResult(false, "Too much time taken to do the work");
            }
            return ValidationResult.ValidResult;
        }
    }
}
