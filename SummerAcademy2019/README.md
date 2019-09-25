# TietoFeedbackTool

This project was created for allowing users to install and gather feedback from their websites. Our project has been conducted by Tieto during Summer Academy 2019.
This project is fully open source and is based on Apache License 2.0.

## Getting Started

Clone this repository into your local machine and run it by using dotnet run in VisualStudio Code or by using IIS Express in VisualStudio, be sure you have installed MS SQL Server and the database was created.

### Prerequisites

Download and install Node.js
```
https://nodejs.org/en/
```

Install angular CLI using Node.js command prompt
```
npm install -g @angular/cli (using node.js)
```

Download and install .NET Core 2.2 SDK
```
https://dotnet.microsoft.com/download/dotnet-core/2.2
```

Download and install Visual Studio 2019
```
https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16
```

Download and install MS SQL 2019
```
https://www.microsoft.com/en-us/sql-server/sql-server-2019
```
### Installing

A step by step series of examples that tell you how to get a development env running

Install Node.js

```
Download and install Node.js from https://nodejs.org/en/
```

Install Visual Studio

```
Download and install Visual Studio 2019 community from https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16
Choose to additionally install ASP.NET and web development, .NET Core cross-platform development, .NET Core 2.2 development tools and Development time IIS support.
```

Install MS SQL 2019

```
Download and install MS SQL 2019 from https://www.microsoft.com/en-us/sql-server/sql-server-2019.
```

Install .NET Core 2.2 SDK
```
Download and install .NET Core 2.2 SDK from https://dotnet.microsoft.com/download/dotnet-core/2.2
```

Install angular cli using Node.js command prompt
```
npm install -g @angular/cli
```

Clone project
```
Clone repository using HTTPS link
```

Build project
```
Press ctrl+shift+b to build application
```

Setup project database
```
Using PowerShell/CMD/PackageManager
Go to project folder e.g. C:\Users\Administrator\Source\Repos\TietoFeedbackTool\SummerAcademy2019\TietoFeedbackTool\TietoFeedbackTool
Type
dotnet ef database update
```

Install packages
```
Using PowerShell/CMD/PackageManager
Go to ClientApp folder e.g. C:\Users\Administrator\Source\Repos\TietoFeedbackTool\SummerAcademy2019\TietoFeedbackTool\TietoFeedbackTool\ClientApp
Type
npm install
```

Run application
```
Use IIS Express in Visual Studio or type
dotnet run
in project folder
If it doesn't automatically open browser, type localhost:44350 in your browser.
```


## Using application
```
You can click "Create new survey"
```
then
```
Complete form with data
```
then
```
You can select domain on the left side of the site
```
then
```
You can see list of questions(surveys), that you already setuped
```
And by clicking "See more"
```
You will see the feedback for that question
```

## Running the tests

Unit tests for back-end are written in C# and are located in .\Test folder. They test general data management, running with build of the project.
Unit tests for front-end angular are written in NightWatch and are located in .\ClientApp\NightwatchTests, these tests check the general functionality of the front-end part of the application.
To start the tests run:
```ng test```
in ClientApp folder.

## Documentation

You can check documentation of the project and methods

Doxygen
```
open index.html in \TietoFeedbackTool.Documentation\html
Alternative way:
In solution explorer Documentation folder open index.html via RMB open in browser or Ctrl + Shift + W
```

Swagger
```
During runtime add /swagger in your browser link at dashboard page
```

## Built With
* [Angular 8](https://angular.io/docs) -  Client-side TypeScript based framework
* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/getting-started/?view=aspnetcore-2.2&tabs=windows) - Cross-platform, high-performance, open-source framework
* [SQL Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-2019) -  Data base hub for data integration.
## Authors
**Team Kangaroos**
* **Dyjeta Sebastian** - [bboydexter1](https://github.com/bboydexter1)
* **Kropaczewska Sylwia** - [kathalaume](https://github.com/kathalaume)
* **Zbytniewski Adam** - [nergosu36](https://github.com/nergosu36)
* **Olejnik Wojciech** - [wolejnik](https://github.com/wolejnik)
* **Grzybek Mateusz** - [mateuszgrzybek](https://github.com/mateuszgrzybek)
* **Woźniak Patryk** - [stealthisnick](https://github.com/StealThisNick)
* **Kubicki Paweł** - [pawlo903](https://github.com/pawlo903)
* **Szumielewicz Patryk** - [szumo222](https://github.com/szumo222)
* **Skrzypa Agata**
* **Kamińska Karolina**
* **Śliwiński Bartosz**
## License
This project is licensed under the Apache License 2.0  License - see the [LICENSE.md](LICENSE.md) file for details
## Acknowledgments
* **Joanna Rogańska**
* **Wojtalewicz Michał**
* **Jakub Nowak**
* **Aleksander Dudek** - [aleksanderdudek](https://github.com/AleksanderDudek)
* **Róża Żabiłowicz**
* **And any other menthors who helped us**
