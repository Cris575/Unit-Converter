namespace Unit_Converter.Services;

public interface IUnitFactorsProvider
{
    IReadOnlyDictionary<string, double> GetLengthFactorsInMeters();
    IReadOnlyDictionary<string, double> GetWeightFactorsInKilograms();
    IReadOnlyDictionary<string, (Func<double, double> ToCelsius, Func<double, double> FromCelsius)> GetTemperaturesFactorsInCelsius();
}

public class UnitFactorsProvider : IUnitFactorsProvider
{
    private static readonly Dictionary<string, double> Lengths = new()
    {
        { "mm", 0.001 },
        { "cm", 0.01 },
        { "m", 1.0 },
        { "km", 1000.0 },
        { "in", 0.0254 },
        { "ft", 0.3048 },
        { "yd", 0.9144 },
        { "mi", 1609.34 }
    };

    public IReadOnlyDictionary<string, double> GetLengthFactorsInMeters() => Lengths;
    
    private static readonly Dictionary<string, double> Weight = new()
    {
        { "mg", 0.000001 },
        { "g", 0.001 },
        { "kg", 1.0 },
        { "oz", 0.0283495 },
        { "lb", 0.453592 },
    };

    public IReadOnlyDictionary<string, double> GetWeightFactorsInKilograms() => Weight;   
    
    private static readonly Dictionary<string, (Func<double, double> ToCelsius, Func<double, double> FromCelsius)> Temperatures 
        = new()
        {
            { "°C", (c => c, c => c) },
            { "°F", (f => (f - 32.0) * 5.0 / 9.0, c => (c * 9.0 / 5.0) + 32.0) },
            { "K", (k => k - 273.15, c => c + 273.15) }
        };

    public IReadOnlyDictionary<string, (Func<double, double> ToCelsius, Func<double, double> FromCelsius)> GetTemperaturesFactorsInCelsius() => Temperatures;
    
    
}