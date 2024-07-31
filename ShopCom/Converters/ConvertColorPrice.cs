using System.Globalization;

namespace ShopCom.Converters;

public class ConvertColorPrice : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var price = (decimal)value;
        if (price >= 0 && price <= 100) { 
            return Colors.Green;
        }

        return Colors.Red;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
