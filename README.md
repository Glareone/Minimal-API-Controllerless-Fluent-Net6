# Minimal-API-.Net6
# Table of content, projects with detailed examples
1. [Fundamentals. Lambdas. Flat Structure file](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter01/Program.cs)  
2. [Architecturing MinimalAPI. Reflection](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter02/Chapter02-Architecturing-minimal-api/PeopleHelper.cs)  
3. [managing CORS for MinimalAPI](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter03-CORS-GlobalAPISettings/Program.cs)  
4. [IOptions, Configuration, IOptionMonitor, IOptionSnapshot, IOptionFactory](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter03-CORS-GlobalAPISettings/Options)  
5. [Exception Handling following IETF Standard and custom handling](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter04-ExceptionHandling)
6. [Logging JsonFormatted and W3C](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter05-Logging/Program.cs)  
7. [Logging using Serilog and AppInsights. Configuration](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter05-Logging-Serilog/appsettings.json)
8. [DTO Fluent Validation. Enrich Swagger with Validation Rules Description](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter06-Model-FluentValidation)
9. [Automapper](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter07-Mapping-AutoMapper)  
10. [Dapper & Automapper](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter08-Dapper)
11. [Authentication using JWT](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter09-Authentication)
12. [Authorization using different methods](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims)
    - [Role-based](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/RoleBasedAdminEndpointHelper.cs)
    - [Policy-based](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/PolicyBasedEndpointHelper.cs)
    - [Policy-Requirement. Custom Policy](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/PolicyRequirementProtectedEndpointHelper.cs)
    - [Fallback & Default Policies](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/Program.cs#L66)
    - [Anonymous](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/AnonymousEndpoints.cs)  
13. [Localization & Globalization using resx. DateTime Converter](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter10-localization)  

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







