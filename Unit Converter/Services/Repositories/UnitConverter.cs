using Unit_Converter.Models;

namespace Unit_Converter.Services.Repositories;
public interface IUnitConverter
{
    public double ConvertLength(double value, double from, double to, IReadOnlyDictionary<string, double> values);
}

public class UnitConverter: IUnitConverter
{
    public double ConvertLength(double value, double from, double to, IReadOnlyDictionary<string, double> values)
    {
        return value / from;
    }
}