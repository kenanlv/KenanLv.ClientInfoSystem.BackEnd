<h1 align="center">
  <br>
  <a href="https://github.com/kenanlv"><img src="https://cdn.iconscout.com/icon/free/png-512/c-programming-569564.png" alt="CISFullStack" width="200"></a>
  <br>
  Client Information System (Back-End)
  <br>
</h1>


<p align="center"> 
this is the <b>back end</b> part of the whole project, you could find frontend <a href="https://github.com/kenanlv/KenanLv.ClientInfoSystem.FrontEnd">here</a>
</p>
<br>
<p align="center">
  <a href="#key-features">Key Features</a> •
  <a href="#how-to-use">How To Use</a> •
  <a href="#proj-struct">Project Structure</a> •
  <a href="#credits">Credits</a> •
  <a href="#license">License</a>
</p>


## Key Features

* Back end built with ASP.NET Core API in C# with SQL server Database and Entity Framework Core.
* Database created with Entity Framework Core First approach using migrations.
* Connected databae with Entity Framework.
* Implemented Dependency Injection for best practice of decoupling.
* Database logic seperated with Business logic
* Created CRUD operations APIs for Front-end to talk with database.


## How To Use

To clone and run this application, you'll need [Git](https://git-scm.com), [Visual Studio](https://visualstudio.microsoft.com/), and [Sql Server Database](https://www.microsoft.com/en-us/sql-server/sql-server-2019) installed on your computer. VS solution `.sln` file is also included in this Repo. You could import this project through Visual Studio

## Project Structure

There are three parts in this project: `Core`, `Infarstructure`, and `API`
> Core holds the fundamental element, things like Database entities, Request and Response Models, and Interfaces

> Infrastructure will implement interfaces(repositories, and services) inside the Core, and it is responsible to hold the Database along with database migrations. 

> API will be the responsible for Restful APIs as well as handle start up instances and storing environement variables. APIs will be inside Controllers, and Dependency Injections will be added to the service when project first starts up and configures.

These three layers are called onion layers, with `Core` in the core, `Infrastructure` in the middle and `API` in the out-most layer.

## Credits

This software uses the following open source packages:

- [Visual Studio](https://visualstudio.microsoft.com/)
- [Sql Server Database](https://www.microsoft.com/en-us/sql-server/sql-server-2019)
- [Entity Framework](https://docs.microsoft.com/en-us/ef/)


## You may also like...

- [ASP.Net Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0)

## License

MIT

---

> [amitmerchant.com](https://www.amitmerchant.com) &nbsp;&middot;&nbsp;
> GitHub [@amitmerchant1990](https://github.com/amitmerchant1990) &nbsp;&middot;&nbsp;
> Twitter [@amit_merchant](https://twitter.com/amit_merchant)

