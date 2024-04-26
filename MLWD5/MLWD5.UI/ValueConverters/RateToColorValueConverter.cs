using System.Globalization;

namespace MLWD5.UI.Converters
{
    internal class RateToColorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            if ((double)value > 6)
                return Colors.LightYellow;

            return Colors.WhiteSmoke;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
