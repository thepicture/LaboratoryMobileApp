using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            DateTime dateBefore = DateTime.Parse((string)value);
            TimeSpan timeDifference = DateTime.Now - dateBefore;
            if (timeDifference.TotalMinutes < 1)
            {
                return Math.Floor(timeDifference.TotalSeconds)
                    .ToString("F0") + " сек. назад";
            }
            else if (timeDifference.TotalHours < 1)
            {
                return Math.Floor(timeDifference.TotalMinutes).ToString("F0")
                    + " мин. назад";
            }
            else if (timeDifference.TotalDays < 1)
            {
                return Math.Floor(timeDifference.TotalHours).ToString("F0")
                    + " ч. назад";
            }
            else if (timeDifference.TotalDays < 31)
            {
                return Math.Floor(timeDifference.TotalDays).ToString("F0")
                    + " дн. назад";
            }
            else if (timeDifference.TotalDays < 365)
            {
                return Math.Floor(timeDifference.TotalDays / 31).ToString("F0")
                    + " мес. назад";
            }
            return Math.Floor(timeDifference.TotalDays / 365).ToString("F0")
                + " г. назад";
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
