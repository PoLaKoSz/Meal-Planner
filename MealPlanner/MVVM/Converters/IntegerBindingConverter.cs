using System;
using System.Windows.Data;

namespace MealPlanner.MVVM.Converters
{
    public class IntegerBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        /// <summary>
        /// Convert input from UI
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isNumeric = int.TryParse(value.ToString(), out int integer);

            if (!isNumeric)
            {
                return 0;
            }

            return integer;
        }
    }
}
