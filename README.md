# ASP.NET Core 3 and Angular 9 - Third Edition

This is the code repository for [ASP.NET Core 3 and Angular 9](https://www.packtpub.com/web-development/asp-net-core-3-and-angular-9-third-edition?utm_source=GitHub&utm_medium=repository), 
published by [Packt](https://www.packtpub.com/?utm_source=GitHub&utm_medium=repository). It contains all the supporting project files necessary to work through the book from start to finish.

## IMPORTANT NOTE
If you experience any issue while running the project while following the book's chapters, please do the following:
- Get the updated project from GitHub and save it in a separate folder
- Right-click to the project you want to run (for example `Chapter_01/HealthCheck`) and ***Set as StartUp Project***
- Execute the `/ClientApp/update-npm.bat` file
- Launch the project in debug mode
In case it works, compare your code with the GitHub files to see what's wrong. Also be sure to check out the book's errata and other useful info regarding the source code from the [Issues page](https://github.com/PacktPublishing/ASP.NET-Core-3-and-Angular-9-Third-Edition/issues).


## About the Book
This book is a sequel of the best-selling book [ASP.NET Core 2 and Angular 5](https://www.packtpub.com/application-development/aspnet-core-2-and-angular-5?utm_source=GitHub&utm_medium=repository).


### Key Features
* Design, build and deploy a Single Page Application or Progressive Web App with ASP.NET Core and Angular.
* Adopt a full-stack approach to effectively handle data management, Web APIs, application design, testing, SEO, security and deploy.
* Turn a Single-Page Application (SPA) into a Progressive Web App (PWA)
* Publish the finalized app on Windows and Linux servers.


### Book Description
The ASP.NET Core and Angular book has established itself as a popular choice for learning full-stack development.
This book will help you become fluent in both frontend and backend web development by combining the impressive capabilities 
of ASP.NET Core 3.1 and Angular 9 from project setup right through the deployment phase.

The book will help you use the .NET Core framework and Web API Controllers to implement the backend with API calls 
and server-side routing. Going further, you will learn to build the Data Model with Entity Framework Core and configure it using 
either a local SQL Server instance or cloud-based data stores such as MS Azure. 
The book will help you handle user input with Angular Reactive Forms and frontend and backend Validators for maximum effect. 
You will explore the advanced debugging and unit testing features provided by xUnit.NET (.NET Core) and Jasmine/Karma (Angular).

Eventually, you will implement various authentication and authorization techniques with the ASP.NET Core Identity system
 and the new IdentityServer, as well as deploy your apps on Windows and Linux Servers using IIS, Kestrel, and NGINX.


### What you will learn
* Implement a Web API interface with ASP.NET Core and consume it with Angular using RxJS Observables
* Create a Data Model using Entity Framework Core with Code-First and Migrations
* Setup and configure a SQL DB server using a local instance or a cloud data store on Azure
* Perform C# and JavaScript debugging using Visual Studio 2019
* TDD and BDD unit testing using xUnit, Jasmine and Karma
* Execute authentication and authorization using ASP.NET Identity, IdentityServer4, and Angular API
* Build Progressive Web Apps and explore Service Workers


### Who This Book Is For
This book is aimed at seasoned ASP.NET developers who already know about ASP.NET Core and Angular in general, 
but want to know more about them and/or understand how to blend them together to craft a production-ready 
Single-Page Application (SPA) or Progressive Web Application (PWA). 

However, the fully-documented code samples and the step-by-step implementation tutorials 
make the book easy to understand even for beginners and novice developers.


## Instructions and Navigation
All of the code is organized into folders. Each folder starts with a number followed by the application name. For example, `Chapter_02`.

The code will look like the following:
```
import { Component } from "@angular/core";

@Component({
    selector: "pagenotfound",
    templateUrl: "./pagenotfound.component.html"
})

export class PageNotFoundComponent {
    title = "Page not Found";
}
```

## Errata
* Page 230: This Address bar value- https://localhost:44344/api/Cities/?pageIndex=0pageSize=10

           _should be replaced with_

           https://localhost:44344/api/Cities/?pageIndex=0&pageSize=10  


## About the Author
Valerio De Sanctis is a skilled IT professional with more than 15 years of experience in lead programming, 
web-based development, and project management using ASP.NET, PHP and Java. 
He held senior positions at a range of financial and insurance companies, most recently serving as Chief Technology Officer, 
Chief Security Officer and Chief Operating Officer at a leading after-sales and IT service provider for 
top-tier life and non-life insurance groups.

During the course of his career Valerio De Sanctis helped many private organizations to implement and maintain 
.NET based solutions, working side by side with many IT industry experts and leading several frontend, 
backend and UX development teams. He designed the architecture and actively oversaw the development 
of a wide number of corporate-level web application projects for high-profile clients, customers and partners 
including London Stock Exchange Group, Zurich Insurance Group, Allianz, Generali, Harmonie Mutuelle, 
Honda Motor, FCA Group, Luxottica, ANSA, Saipem, ENI, Enel, Terna, Banzai Media, Virgilio.it, Repubblica.it, and Corriere.it.

He is an active member of the Stack Exchange Network, providing advice and tips for .NET, JavaScript, 
HTML5 and Web related topics on the StackOverflow, ServerFault, and SuperUser communities. 
Most of his projects and code samples are available under open-source licenses on GitHub, BitBucket, NPM, 
CocoaPods, JQuery Plugin Registry, and WordPress Plugin Repository. 
He's also a [Microsoft Most Valuable Professional](https://mvp.microsoft.com/en-us/PublicProfile/5003202) (MVP) 
for Developer Technologies, an annual award that recognizes exceptional technology community leaders worldwide 
who actively share their high quality, real world expertise with users and Microsoft.

Since 2014 he runs an IT-oriented, web-focused blog at [www.ryadel.com](https://www.ryadel.com/) featuring news, reviews, code samples and guides to help developers and tech enthusiasts from all around the world: he wrote various books on web development, many of which have become best sellers on Amazon with tens of thousands of copies sold worldwide.

You can reach him on [GitHub](https://github.com/Darkseal), [StackOverflow](https://stackoverflow.com/users/1233379/darkseal) and [LinkedIn](https://www.linkedin.com/in/darkseal/).


## Related Products
* [ASP.NET Core and Angular 2](https://www.packtpub.com/application-development/aspnet-core-and-angular-2?utm_source=GitHub&utm_medium=repository) (first edition)
* [ASP.NET Core 2 and Angular 5](https://www.packtpub.com/application-development/aspnet-core-2-and-angular-5?utm_source=GitHub&utm_medium=repository) (second edition)
