using System;
using System.Globalization;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Converters
{
    public class PriceToGraphConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            decimal price = (decimal)value;
            return price == 0
                ? App.Current.MainPage.Width / 2
                : (object)(((decimal)App.Current.MainPage.Width / 2)
                - (1 / price * 5000));
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
