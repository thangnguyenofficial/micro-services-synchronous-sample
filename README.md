# Microservices Get Started

## Business Case

Global Ticket is a global ticket company. They want to build the website to sell event ticket such as theater, concert and etc
My responsibility is develop global ticket website using micro-services architecture and applying synchronous communication between services

**Functional requirements**

* Event catalog
* Shopping basket
* Payment

**Nonfunctional requirements**

* Flexible scaling 
* Deployment independently - Continuous delivery
* Separated teams
* Easy to expand
* Reliable

## Traditional Approach

<img src="https://i.ibb.co/f0N2zzV/traditional.png" alt="traditional" border="0"></a><br />

**Benfits of Monoliths**

* Ease of development rather than call over the wire
* Ease of depyloment - all in one application

**Drawbacks of Monoliths**

* Difficult to maintain a huge application
* More bigger = more complex
* Hard to scale out
* Upgrade technologies
* Exhausted when working with multiple teams

## The Microservices Approach

<img src="https://i.ibb.co/SxGg2NY/microservices.png" alt="microservices" border="0">

**Benfits of Microservices**

* Reducing dependencies of each services to each other
* Easy to develop, maintain, upgrade technologies for individual services
* High availability and scaling out, An application can be active even one or two services are pending
* Team collaborate is better

**Drawbacks of Microservices**

* More complex and it is not suitable for easy games
* Require high skills for development team beyond coding
* Deployment and monitoring is challenge

## Prerequisites

**In order to build and run the project, it is recommended that you have the following installed**

* .NET Core 3.1 SDK. You can test that you have it installed by entering the command dotnet --list-sdks
* Install EF Core Tool to migrate database
* Visual Studio 2019 (Community Edition or Greater) or Visual Studio Code

## Launch Project

**Launch in a browser**

* If you have followed the instructions, The client website will be running on port 5000, which you can access in the browser at https://localhost:5000.
* The Event Catalog microservice will be running on port 5001 and you can view the API documentation at https://localhost:5001/swagger
* The Shopping Basket microservice will be running on port 5002 and you can view the API documentation at https://localhost:5002/swagger

