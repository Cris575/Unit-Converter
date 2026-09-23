using Unit_Converter.Models;

namespace Unit_Converter.Services.Repositories;
public interface IUnitConverter
{
    // Método para unidades proporcionales (Longitud, Peso, etc.)
    double ConvertStandard(UnitConverterViewModel unitConverter, IReadOnlyDictionary<string, double> values);

    // Método para Temperaturas
    double ConvertTemperature(
        UnitConverterViewModel unitConverter, 
        IReadOnlyDictionary<string, (Func<double, double> ToCelsius, Func<double, double> FromCelsius)> tempFactors);
}

public class UnitConverter: IUnitConverter
{
    public double ConvertStandard(UnitConverterViewModel unitConverter, IReadOnlyDictionary<string, double> values)
    {
        double measure = unitConverter.Measure;
        double unitFrom = values[unitConverter.UnitFrom];
        double unitTo = values[unitConverter.UnitTo];

        return (measure * unitFrom) / unitTo;
    }

    public double ConvertTemperature(
        UnitConverterViewModel unitConverter, 
        IReadOnlyDictionary<string, (Func<double, double> ToCelsius, Func<double, double> FromCelsius)> tempFactors)
    {
        double measure = unitConverter.Measure;
        var from = tempFactors[unitConverter.UnitFrom];
        var to = tempFactors[unitConverter.UnitTo];

        double valueInCelsius = from.ToCelsius(measure);
        return to.FromCelsius(valueInCelsius);
    }
} 