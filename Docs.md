# Documentation

A simple, WIP, unofficial .NET Core library for OpenWeatherMap

# Notes

-   currently it only supports "current weather"

# How to use

## Constructors:

the most basic constructor is:

```
Current currentWeather = new Current(API_KEY);
```

you can also specify your IRestService implementation like this

```
Current currentWeather = new Current(API_KEY, MyRestService);
```

you may also want to set the measurement units

```
Current currentWeather = new Current(API_KEY, WeatherUnits.Imperial);
```

you may also want to specify your IRestService implementation AND set the measurement units

```
Current currentWeather = new Current(API_KEY, MyRestService, WeatherUnits.Imperial);
```

then you can call any of the methods explained below

&nbsp;

## Methods:

### Async methods, i.e. return **WeatherData**

```
GetWeatherDataByZipAsync(string zipCode, string countryCode)
GetWeatherDataByCityNameAsync(string cityName, string countryCode = "")
GetWeatherDataByCityIdAsync(int cityId)
GetWeatherDataByCoordinatesAsync(double lat, double lon)
GetWeatherDataByCoordinatesAsync(Coordinates coordinates)
```

&nbsp;

### Tasks

```
GetWeatherDataByZip(string zipCode, string countryCode)
GetWeatherDataByCityName(string cityName, string countryCode = "")
GetWeatherDataByCityId(int cityId)
GetWeatherDataByCoordinates(double lat, double lon)
GetWeatherDataByCoordinates(Coordinates coordinates)
```
