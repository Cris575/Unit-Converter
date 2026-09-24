namespace Unit_Converter.Services;

public interface IUnitFactorsProvider
{
    IReadOnlyDictionary<string, double> GetLengthFactorsInMeters();
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
}

// public class SQLUnitFactorsProvider : IUnitFactorsProvider
// {
//     private static readonly Dictionary<string, double> Lengths = new()
//     {
//         { "Millimeter", 0.001 },
//         { "Centimeter", 0.01 },
//         { "Meter", 1.0 },
//         { "Kilometer", 1000.0 },
//         { "Inch", 0.0254 },
//         { "Foot", 0.3048 },
//         { "Yard", 0.9144 },
//         { "Mile", 1609.34 }
//     };
//
//     public IReadOnlyDictionary<string, double> GetLengthFactorsInMeters() => Lengths;
// }