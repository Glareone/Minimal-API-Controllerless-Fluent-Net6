# Minimal API and best practices for .Net8 and .Net6
# Table of content, projects with detailed examples
1. [Fundamentals. Lambdas. Flat Structure file](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter01/Program.cs)  
2. [Architecturing MinimalAPI. Reflection & Class registration](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter02/Chapter02-Architecturing-minimal-api/PeopleHelper.cs)  
3. [CORS for MinimalAPI](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter03-CORS-GlobalAPISettings/Program.cs)  
4. [IOptions, Configuration, IOptionMonitor, IOptionSnapshot, IOptionFactory](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter03-CORS-GlobalAPISettings/Options)  
5. [Exception Handling following IETF Standard and custom handling](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter04-ExceptionHandling)
6. Logging
    - [Logging JsonFormatted and W3C](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter05-Logging/Program.cs)  
    - [Logging using Serilog and AppInsights. Configuration](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter05-Logging-Serilog/appsettings.json)  
10. [DTO Fluent Validation. Enrich Swagger with Validation Rules Description](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter06-Model-FluentValidation)
11. [Automapper](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter07-Mapping-AutoMapper)  
12. [Dapper & Automapper](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter08-Dapper)
13. [Authentication using JWT](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter09-Authentication)
14. [Authorization using different methods](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims)
    - [Role-based](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/RoleBasedAdminEndpointHelper.cs)
    - [Policy-based](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/PolicyBasedEndpointHelper.cs)
    - [Policy-Requirement. Custom Policy](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/PolicyRequirementProtectedEndpointHelper.cs)
    - [Fallback & Default Policies](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/Program.cs#L66)
    - [Anonymous](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/AnonymousEndpoints.cs)  
15. [Localization & Globalization using resx. DateTime Converter](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter10-localization)
16. Benchmakring ControllerAPI & MinimalAPI
    - [BenchmarkDotNet Runner](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter11-BenchmarkDotNet-Runner-forAPI)  
    - [MinimalAPI and K6 scripts](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter11-Performance-Benchmark-K6-BenchmarkDotNet)  
    - [ControllerAPI and K6 scripts](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter11-2-Controllers-K6-BenchmarkDotNet)  
    - [Benchmark results](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter11-Performance-Benchmark-K6-BenchmarkDotNet/BenchmarkDotNet-Results)  
17. Error handling, RFC 9547 Modern standard and outdated RFC 7807
    - [RFC9547 with example](#rfc-9457-july-2023-modern---must-specify-the-details-of-each-validation-error)
    - [RFC 7807 with example](#rfc-7807-obsolete)

## Minimal API .Net6. General Information
Examples: 
  - [Fundamentals. Lambdas. Flat Structure file](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter01/Program.cs)  
  - [Architecturing MinimalAPI. Reflection](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter02/Chapter02-Architecturing-minimal-api/PeopleHelper.cs)    

![image](https://user-images.githubusercontent.com/4239376/196035107-49334f65-f835-4a60-af10-e27af4548b96.png)  
![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/f0391bed-e78d-4d20-9212-85e386abfdb3)  

## CORS
Examples:
  - [managing CORS for MinimalAPI](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter03-CORS-GlobalAPISettings/Program.cs)

![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/f916de7f-61a6-45db-a09f-a75f4bd06768)  
![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/37dc9ea4-d702-4f9c-a745-4c4e6938024e)
### Run FrontendSPA to test CORS
In order to test CORS you may run Index.html file hosted under Course03 project in Frontend-for-CORS folder using LiveReloadServer

To Install LiveReloadServer for .Net6 and .Net7: 
1. cmd -> dotnet install -g --version 1.1.0 LiveReloadServer
2. cmd -> dontnet install -g LiveReloadServer

To host Index.Html file in server's memory:
1. cmd -> livereloadserver {BasePath}\Chapter03-CORS-GlobalAPISettings\Folder-For-Frontend


## IOptions vs IOptionMonitor vs IOptionSnapshot
Examples:
  - [IOptions, Configuration, IOptionMonitor, IOptionSnapshot, IOptionFactory](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter03-CORS-GlobalAPISettings/Options)

![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/06ab9e0b-4bac-4712-bf90-78eb0c6b9890)

## Error handling using IETF Standard
### RFC 9457 (July 2023, Modern) - must specify the details of each validation error
RFC 9457 Doc:  
  - https://www.rfc-editor.org/rfc/rfc9457.html  

Media Type: `application/problem+json`  

### Format proposed by the standard:
```
HTTP/1.1 422 Unprocessable Content
Content-Type: application/problem+json
Content-Language: en

{
 "type": "https://example.net/validation-error",
 "title": "Your request is not valid.",
 "errors": [
             {
               "detail": "must be a positive integer",
               "pointer": "#/age"
             },
             {
               "detail": "must be 'green', 'red' or 'blue'",
               "pointer": "#/profile/color"
             }
          ]
}
```

### Implemented example with traceId and requestId:
```
{
  "type": "Bad Request",
  "title": "Something went wrong with OpenWeather Service",
  "status": 400,
  "detail": "Response status code does not indicate success: 401 (Unauthorized).",
  "instance": "GET /get-weather",
  "requestId": "0HN8TPG6GMH5R:00000007",
  "traceId": "00-352bd6ae37ee396964f8a999d6762418-ffde06642c1bdaf4-00"
}
```

Examples:
  - [RFC 9457 Exception Handling](https://github.com/Glareone/Minimal-API-Controllerless-Fluent-Net6/tree/main/Chapters/MinimalAPI/Chapter12-API-Error-Format%20RFC%209457)



### RFC 7807 (OBSOLETE)
RFC 7807 (OBSOLETE)  And Documentation: 
  - https://datatracker.ietf.org/doc/html/rfc7807  

Media Type: `application/problem+json`
Proposed Format:  
```
 HTTP/1.1 403 Forbidden
   Content-Type: application/problem+json
   Content-Language: en

   {
    "type": "https://example.com/probs/out-of-credit",
    "title": "You do not have enough credit.",
    "detail": "Your current balance is 30, but that costs 50.",
    "instance": "/account/12345/msgs/abc",
    "balance": 30,
    "accounts": ["/account/12345",
                 "/account/67890"]
   }
```  

Examples:
  - [Exception Handling following IETF Standard and custom handling](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter04-ExceptionHandling)

![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/594e95f7-32ac-4be4-a09b-4840a29022f7)


## Configuring Logging in .Net6 MinimalAPI
Examples:
  - [Logging JsonFormatted and W3C](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter05-Logging/Program.cs)  
  - [Logging using Serilog and AppInsights. Configuration](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter05-Logging-Serilog/appsettings.json)

![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/d7408bbf-d584-4f7b-84bb-ff44d2ea0d0c)  
![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/1fb6498e-cab9-406b-bcfa-256a93a5662b)  

## Fluent Validation
Examples:
  - [DTO Fluent Validation. Enrich Swagger with Validation Rules Description](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter06-Model-FluentValidation)  

![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/43290abf-a299-4ab8-a0ed-f0a4e94cdc8f)

## Benchmarking using K6
http_req: 20078 - means a number of requests handled per second and total number of them  
![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/bd08bb64-3aa3-4e52-995f-256f30e17c27)    

### Compare Controllers vs MinimalAPI
![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/f5bb6c27-50e1-4a28-ba3d-87cdcccbd689)  
  
The difference is approximately 5-20%.  
![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/8bf55092-e83c-4b0d-a0c0-600ece565836)  
![results](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/0c687bfe-1bcc-4258-99a6-7b8b1280207a)  
![minimalapi-text-plain](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/7cdc68ca-eae3-4673-94ab-388c4069009a)  
![controllerapi-text-plain](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/45084825-6a1d-467a-bbc9-98c5e8cca4d6)  



