# StockWatcher
<b>WPF on .NET Framework application</b>

Welcome! This is the repository for Stock Watcher project.
This application developed using WPF C# Technology under .NET Framework for tutorial purposes.

StockWatcher application shows updated stock information straight from Yahoo Finance API.
Although it's .NET Framework based, I combined new libraries for learning and to make things a bit more interesting.
Also, the application is using many .NET Core libraries and structuring including IoC, Loggin and Configuration libraries.

Some key features the application has:
* Many WPF features such as XAML, converters, Custom controls and more...
* Pure MVVM architecture with the most recent Microsoft.Toolkit.Mvvm
* Login form
* Registration form
* form validation using FluentValidation 
* Full dependency injection support
* Logging support using Serilog
* Database based on SQL
* Written stored procedures
* Querying database using Dapper
* Candle stick chart using FancyCandels
* Writing API for yahoo finance
* Theme support
* Http client communication
* Json serialization
* Tests using MSTests


Light theme:<br />
![main-light](https://user-images.githubusercontent.com/32191482/131389635-379dba34-547c-466c-89c8-28ce95b6b22b.png)

Dark theme:<br />
![main-dark](https://user-images.githubusercontent.com/32191482/131389719-a544abb8-e59b-406e-8a54-8e604941ff79.png)

Login page:<br />
![sign-in](https://user-images.githubusercontent.com/32191482/131392144-cc046482-2ac6-41c9-8125-8d657dc34686.png)

dbo.Users table:<br />
![user](https://user-images.githubusercontent.com/32191482/131393005-1083dbdb-efab-421e-99b6-80e19b1b947b.png)


Key libraries used:
* Dapper
* FancyCandles
* FluentValidation
* Microsoft.Extensions.Configuration
* Microsoft.Extensions.Configuration.Abstractions
* Microsoft.Extensions.Configuration.Binder
* Microsoft.Extensions.Configuration.FileExtensions
* Microsoft.Extensions.Configuration.Json
* Microsoft.Extensions.DependencyInjection
* Microsoft.Extensions.Logging
* Microsoft.ToolkitMvvm
* MSTest
* Newtonsoft.Json
* Serilog
