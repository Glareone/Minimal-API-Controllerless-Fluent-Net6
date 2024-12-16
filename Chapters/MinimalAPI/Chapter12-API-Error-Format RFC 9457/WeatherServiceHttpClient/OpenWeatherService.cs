using Microsoft.AspNetCore.WebUtilities;

namespace Chapter12_API_Error_Format.WeatherServiceHttpClient;

public sealed class OpenWeatherService
{
    private readonly HttpClient _httpClient;

    public OpenWeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        // OpenWeatherMap URI example:
        // https://api.openweathermap.org/data/3.0/onecall?lat=33.44&lon=-94.04&appid={API key}
        _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/3.0/");
    }

    public async Task<OpenWeatherResponse?> GetWeatherData() {
        
        var query = new Dictionary<string, string>()
        {
            ["lat"] = "33.44",
            ["lon"] = "-94.04",
            ["appid"] = "XXXXXXXXXX"
        };

        var uri = QueryHelpers.AddQueryString("onecall", query);
        
        var response = await _httpClient.GetFromJsonAsync<OpenWeatherResponse>(uri);
        return response;
    }
        
}
