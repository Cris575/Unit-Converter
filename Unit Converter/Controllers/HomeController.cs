using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Unit_Converter.Models;
using Unit_Converter.Services;
using Unit_Converter.Services.Repositories;

namespace Unit_Converter.Controllers;

public class HomeController : Controller
{
    private readonly IUnitConverter _unitConverter;
    private readonly IUnitFactorsProvider _unitFactorsProvider;

    public HomeController(IUnitConverter unitConverter, IUnitFactorsProvider  unitFactorsProvider)
    {
        _unitConverter = unitConverter;
        _unitFactorsProvider = unitFactorsProvider;
    }
    
    public IActionResult Index(UnitConverterViewModel unitConverter)
    {
        return View(unitConverter);
    }
    
    public IActionResult Weight(UnitConverterViewModel unitConverter)
    {
        return View(unitConverter);
    } 
    
    public IActionResult Temperatures(UnitConverterViewModel unitConverter)
    {
        return View(unitConverter);
    }

    [HttpPost]
    public IActionResult UnitConvert(UnitConverterViewModel unitConverter)
    {
        switch (unitConverter.View)
        {
            case "Length":
                var lengthFactors = _unitFactorsProvider.GetLengthFactorsInMeters();
                unitConverter.Value = _unitConverter.ConvertStandard(unitConverter, lengthFactors);
                break;

            case "Weight":
                var weightFactors = _unitFactorsProvider.GetWeightFactorsInKilograms();
                unitConverter.Value = _unitConverter.ConvertStandard(unitConverter, weightFactors);
                break;

            case "Temperatures":
                var tempFactors = _unitFactorsProvider.GetTemperaturesFactorsInCelsius();
                unitConverter.Value = _unitConverter.ConvertTemperature(unitConverter, tempFactors);
                break;
        }

        return View("Index", unitConverter);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}