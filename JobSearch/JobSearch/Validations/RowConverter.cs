using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace JobSearch.Validations
{
    [ValueConversion(typeof(double), typeof(Brush))]
    public class RowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double val = double.Parse(value.ToString());
            if (val > 8)
            {
                return Brushes.Pink;
            }
            else return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
