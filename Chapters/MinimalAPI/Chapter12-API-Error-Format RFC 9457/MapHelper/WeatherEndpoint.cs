﻿using Chapter12_API_Error_Format.ErrorHandling;
using Chapter12_API_Error_Format.WeatherServiceHttpClient;
using Microsoft.AspNetCore.Mvc;

namespace Chapter12_API_Error_Format.MapHelper;

public class WeatherEndpoint : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-weather", GetWeatherHandler)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .WithName("OkResult");
    }

    private async Task<IResult> GetWeatherHandler(OpenWeatherService openWeatherService)
    {
        try
        {
            var response = await openWeatherService.GetWeatherData();
            return Results.Ok(response);
        }
        catch (Exception e)
        {
            throw new ProblemException("Something went wrong with OpenWeather Service", e.Message);
        }    
    }
}
