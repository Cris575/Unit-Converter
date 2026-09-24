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
                    if (!lengthFactors.ContainsKey(unitConverter.UnitFrom) ||
                        !lengthFactors.ContainsKey(unitConverter.UnitTo))
                    {
                        return View("Index", unitConverter);
                    }
                    unitConverter.Value = Math.Round(_unitConverter.ConvertStandard(unitConverter, lengthFactors),4);
                    break;

                case "Weight":
                    var weightFactors = _unitFactorsProvider.GetWeightFactorsInKilograms();
                    if (!weightFactors.ContainsKey(unitConverter.UnitFrom) ||
                        !weightFactors.ContainsKey(unitConverter.UnitTo))
                    {
                        return View("Index", unitConverter);
                    }
                    unitConverter.Value = Math.Round(_unitConverter.ConvertStandard(unitConverter, weightFactors),4);
                    break;

                case "Temperatures":
                    var tempFactors = _unitFactorsProvider.GetTemperaturesFactorsInCelsius();
                    if (!tempFactors.ContainsKey(unitConverter.UnitFrom) ||
                        !tempFactors.ContainsKey(unitConverter.UnitTo))
                    {
                        return View("Index", unitConverter);
                    }
                    unitConverter.Value = Math.Round(_unitConverter.ConvertTemperature(unitConverter, tempFactors),4);
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