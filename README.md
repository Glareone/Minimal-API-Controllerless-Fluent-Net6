# Minimal-API-.Net6
Minimal API .Net6

![image](https://user-images.githubusercontent.com/4239376/196035107-49334f65-f835-4a60-af10-e27af4548b96.png)  
![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/f0391bed-e78d-4d20-9212-85e386abfdb3)  


# Table of content
1. [Fundamentals. Lambdas. Flat Structure file](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter01/Program.cs)
2. [Architecturing MinimalAPI. Reflection](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter02/Chapter02-Architecturing-minimal-api/PeopleHelper.cs)  
3. [managing CORS for MinimalAPI](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter03-CORS-GlobalAPISettings/Program.cs)  
4. [IOptions, Configuration, IOptionMonitor, IOptionSnapshot, IOptionFactory](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter03-CORS-GlobalAPISettings/Options)  
5. Error Handling following IETF Standard and handling on your own (In progress)


## CORS
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
![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/06ab9e0b-4bac-4712-bf90-78eb0c6b9890)

## Error handling using IETF Standard
![image](https://github.com/Glareone/Minimal-API-.Net6/assets/4239376/594e95f7-32ac-4be4-a09b-4840a29022f7)




