using System;
using System.Globalization;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Converters
{
    public class DateTimeToAgeConverter : IValueConverter
    {
        private const int DaysInYear = 365;

        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            DateTime date = DateTime.Parse((string)value);
            return Math.Floor((DateTime.Now - date).TotalDays / DaysInYear);
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            return null;
        }
    }
}
