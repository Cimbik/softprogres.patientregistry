using System.Globalization;
using System.Windows.Data;
using SoftProgres.PatientRegistry.Desktop.Models;

namespace SoftProgres.PatientRegistry.Desktop.Converters;

public class SexEnumToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // Kontrola, či hodnota je enum typu Sex
        if (value is Sex sex)
        {
            switch (sex)
            {
                case Sex.Male:
                    return "muž";
                case Sex.Female:
                    return "žena";
                case Sex.Unknown:
                default:
                    return "neznáme";
            }
        }
        // V prípade neznámej hodnoty vráti "neznáme"
        return "neznáme";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // Tu netreba robiť nič.
        throw new NotImplementedException();
    }
}