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
    
    public IActionResult Index()
    {
        var units = _unitFactorsProvider.GetLengthFactorsInMeters();
        _unitConverter.ConvertLength(1, 2, 3, units);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult UnitConvert(UnitConverterViewModel unitConverter)
    {
       return View(unitConverter);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}