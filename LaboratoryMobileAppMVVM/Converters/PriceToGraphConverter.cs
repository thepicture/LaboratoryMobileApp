using System;
using System.Globalization;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Converters
{
    public class PriceToGraphConverter : IValueConverter
    {
        private const int HalfOfScreenFactor = 2;
        private const int MaxCostFactor = 5000;

        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            decimal price = (decimal)value;
            return price == 0
                ? App.Current.MainPage.Width / HalfOfScreenFactor
                : (object)(((decimal)App.Current.MainPage.Width / HalfOfScreenFactor)
                - (1 / price * MaxCostFactor));
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
