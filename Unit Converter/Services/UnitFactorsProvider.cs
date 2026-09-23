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
        { "Millimeter", 0.001 },
        { "Centimeter", 0.01 },
        { "Meter", 1.0 },
        { "Kilometer", 1000.0 },
        { "Inch", 0.0254 },
        { "Foot", 0.3048 },
        { "Yard", 0.9144 },
        { "Mile", 1609.34 }
    };

    public IReadOnlyDictionary<string, double> GetLengthFactorsInMeters() => Lengths;
    
    private static readonly Dictionary<string, double> Weight = new()
    {
        { "Milligram", 0.000001 },
        { "Gram", 0.001 },
        { "Kilogram", 1.0 },
        { "Ounce", 0.0283495 },
        { "Pound", 0.453592 },
    };

    public IReadOnlyDictionary<string, double> GetWeightFactorsInKilograms() => Weight;   
    
    private static readonly Dictionary<string, (Func<double, double> ToCelsius, Func<double, double> FromCelsius)> Temperatures 
        = new()
        {
            { "Celsius", (c => c, c => c) },
            { "Fahrenheit", (f => (f - 32.0) * 5.0 / 9.0, c => (c * 9.0 / 5.0) + 32.0) },
            { "Kelvin", (k => k - 273.15, c => c + 273.15) }
        };

    public IReadOnlyDictionary<string, (Func<double, double> ToCelsius, Func<double, double> FromCelsius)> GetTemperaturesFactorsInCelsius() => Temperatures;
    
    
}