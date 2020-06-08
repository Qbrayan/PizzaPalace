#  MVC

Example .Net Core application  implemented  with ASP.NET Core 3.1 and kendoUI.


### How to test

I recommend you  use [Visual Studio].

First of all, clone this repository and open it in terminal. Then restore all dependencies and run the project. Since it is configured to use [Entity Framework InMemory](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/) provider, the project will run without any issues.

```sh
$ git clone  https://github.com/Qbrayan/PizzaPalace.git
$ cd PizzaPalace/PizzaPalace
$ dotnet restore
$ dotnet run
```