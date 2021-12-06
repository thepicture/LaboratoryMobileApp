using LaboratoryMobileAppMVVM.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Converters
{
    public class PriceToGraphConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            if (price == 0)
            {
                return App.Current.MainPage.Width / 2;
            }
            else
            {
                return ((decimal)App.Current.MainPage.Width / 2) - (1 / price * 5000);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
