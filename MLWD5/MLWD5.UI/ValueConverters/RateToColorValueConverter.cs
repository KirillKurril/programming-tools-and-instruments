using System.Globalization;

namespace MLWD5.UI.Converters
{
    internal class RateToColorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            if ((int)value < 6)
                return Colors.Yellow;

            return Colors.WhiteSmoke;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
