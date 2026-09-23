namespace Unit_Converter.Models;

public class UnitConverterViewModel
{
    public double Measure { get; set; } = 0;
    public double? Value { get; set; } = null;
    public string UnitFrom { get; set; } = "";
    public string UnitTo { get; set; } = "";
    public string View { get; set; } = "";
    
}