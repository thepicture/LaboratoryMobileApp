using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Converters
{
    public class AuthorConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            return string.Join(" ", ((string)value).Split(' ').ToList().Skip(1));
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
