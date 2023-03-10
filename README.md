# _Hair Salon_

#### By _Cameron Abel_

#### _Suped up appointment book for Clair's Salon_

## Technologies Used

- _C#_
- _ASP.Net Core MVC_
- _Entity Framework Core_
- _MySQL_
- _JavaScript_

## Description

_Demonstrates CRUD methods using the ASP.NET MVC and MySQL._

## Setup/Installation Requirements

### Database Installation

A sample database `cameron_abel.sql` file is provided with this repository. If using MySQL Workbench, simply import this file as a new schema.

- Clone this repository to your local machine
- Navigate to `HairSalon.Solution\HairSalon`
- Create a new file called `appSettings.json`. Paste into this file the following code and replace `uid` and `pwd` fields with your own username and password for MySQL. If you changed the name of the database schema on import, update the `database` field to match:

```JSON
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=cameron_abel;uid=root;pwd=epicodus;"
  }
}
```

- Still within the `HairSalon` directory, execute `dotnet run`

## Known Bugs

- ViewBag issues crop up, but may be resolved when not editing the project
- JavaScript feels a little flaky

## License

_MIT_

Copyright (c) _2023_ _Cameron Abel_

## Image Credits

<a href="https://www.vecteezy.com/free-vector/holiday">Holiday Vectors by Vecteezy</a>

<a href="https://www.vecteezy.com/free-vector/brown">Brown Vectors by Vecteezy</a>

<a href="https://www.vecteezy.com/free-vector/scissors">Scissors Vectors by Vecteezy</a>
