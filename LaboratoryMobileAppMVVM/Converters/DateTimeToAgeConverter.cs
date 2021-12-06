using System;
using System.Globalization;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Converters
{
    public class DateTimeToAgeConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            DateTime date = DateTime.Parse((string)value);
            return Math.Floor((DateTime.Now - date).TotalDays / 365);
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
