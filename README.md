# Unit Converter

A small ASP.NET Core MVC web application for converting length, weight, and temperature values. The application provides a browser-based interface with separate navigation pages for each conversion category and displays results rounded to four decimal places.

## Features

- Length conversions
- Weight conversions
- Temperature conversions
- Responsive UI built with Bootstrap
- Separate conversion pages available from the navigation bar
- No database or external service required

## Requirements

- .NET SDK 9.0 or a compatible newer SDK
- A modern web browser

The repository includes a `global.json` file that selects the .NET 9 SDK and permits roll-forward to a newer major SDK when necessary.

## Getting started

1. Clone the repository and move into the project directory:

   ```bash
   git clone https://github.com/Cris575/Unit-Converter.git
   cd Unit-Converter
   ```

2. Restore the project dependencies:

   ```bash
   dotnet restore
   ```

3. Build the solution:

   ```bash
   dotnet build
   ```

4. Start the application:

   ```bash
   dotnet run --project "Unit Converter/Unit Converter.csproj"
   ```

5. Open the URL printed by the application. The default development URLs are:
   - `http://localhost:5052`
   - `https://localhost:7007`

   The HTTPS development certificate may need to be trusted on your machine. If HTTPS is not configured, use the HTTP URL.

## Using the converter

1. Choose a conversion category from the navigation bar:
   - **Length**
   - **Weight**
   - **Temperature**
2. Enter the value to convert.
3. Select the source unit and destination unit.
4. Select **Submit**.
5. Review the result and select **Reset** to start another conversion.

## Supported units

| Category    | Units                                                                                                                   |
| ----------- | ----------------------------------------------------------------------------------------------------------------------- |
| Length      | Millimeter (`mm`), centimeter (`cm`), meter (`m`), kilometer (`km`), inch (`in`), foot (`ft`), yard (`yd`), mile (`mi`) |
| Weight      | Milligram (`mg`), gram (`g`), kilogram (`kg`), ounce (`oz`), pound (`lb`)                                               |
| Temperature | Celsius (`°C`), Fahrenheit (`°F`), Kelvin (`K`)                                                                         |

Length and weight values are converted through a common base unit: meters for length and kilograms for weight. Temperature values are converted through Celsius.

## Project structure

```text
.
├── Unit Converter.sln
├── global.json
├── README.md
└── Unit Converter/
    ├── Controllers/
    │   └── HomeController.cs
    ├── Models/
    │   └── UnitConverterViewModel.cs
    ├── Services/
    │   ├── Repositories/UnitConverter.cs
    │   └── UnitFactorsProvider.cs
    ├── Views/
    │   ├── Home/
    │   └── Shared/
    ├── wwwroot/
    │   ├── css/
    │   ├── js/
    │   └── lib/
    ├── Program.cs
    └── Unit Converter.csproj
```

### Important files

- `Program.cs` registers MVC and the conversion services, then configures routing and HTTPS redirection.
- `Controllers/HomeController.cs` serves the conversion pages and handles form submissions.
- `Services/UnitFactorsProvider.cs` contains the supported units and conversion factors.
- `Services/Repositories/UnitConverter.cs` contains the standard-unit and temperature conversion algorithms.
- `Views/Home/` contains the forms and result display.

## Routes

| Route                    | Purpose                     |
| ------------------------ | --------------------------- |
| `/` or `/Home/Index`     | Length converter            |
| `/Home/Weight`           | Weight converter            |
| `/Home/Temperatures`     | Temperature converter       |
| `POST /Home/UnitConvert` | Processes a conversion form |

The conversion form submits `Measure`, `UnitFrom`, `UnitTo`, and `View` values to `POST /Home/UnitConvert`. This is an MVC form endpoint, not a JSON REST API.

## Adding or changing units

To add a length or weight unit:

1. Add the unit and its factor relative to the base unit in `UnitFactorsProvider.cs`.
2. Add the same unit as an option in the corresponding Razor view:
   - `Views/Home/_LengthConverter.cshtml`
   - `Views/Home/_WeightConverter.cshtml`
3. For temperature units, add the `ToCelsius` and `FromCelsius` functions to the temperature factor dictionary and add the matching options in `Views/Home/_Temperatures.cshtml`.

Keep the option value in the view identical to the dictionary key in `UnitFactorsProvider.cs`.

## Development commands

Run the application with the HTTPS profile:

```bash
dotnet run --project "Unit Converter/Unit Converter.csproj" --launch-profile https
```

Build the solution in Release mode:

```bash
dotnet build "Unit Converter.sln" --configuration Release
```

Clean generated build output:

```bash
dotnet clean "Unit Converter.sln"
```

Generated `bin/` and `obj/` directories, IDE files, and local user settings are excluded by `.gitignore`.

## License

No license file is currently included in the repository. Add a license before distributing or reusing the project publicly.
