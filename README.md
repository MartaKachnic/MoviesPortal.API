# MoviesPortal.API

> Web API built with ASP.NET Core 5

## Table of contents
* [General info](#general-info)
* [How to run it locally](#how-to-run-it-locally)
* [Endpoints](#endpoints)
* [Technologies](#technologies)
* [Prerequisites](#prerequisites)
* [Status](#status)

## General info

MoviesPortal.API is a web API built with ASP.NET CORE 5. Application stores movies and movie ratings in a local database - MS SQL. User is able to fetch movies and rate them. Authentication and authorization is based on JWT (JSON Web Token). 

## How to run it locally

1. Clone repository
```
git clone https://github.com/MartaKachnic/MoviesPortal.API.git
```
2. Open the .sln project

3. Change the "ConnectionStrings" in the appsettings.json

4. Add Migrations and Update Database on the Package Manager Console
```
add-migration <migrationname>

update-database
```
5. Run project

## Endpoints

### Account

`POST /api/account/register` - Create a new account <br />
`POST /api/account/login` - Login into your account <br />

### Genre

`GET /genres` - Get list of genres <br />

### Movie

`GET /movies` - Get list of movies <br />
`GET /movies/{movieId}` - Get details of specified movie <br />
`PUT /movies/{movieId}` - Edit a specified movie <br />
`DELETE /movies/{movieId}` - Delete a specified movie <br />
`POST /movies/Add` - Add a new movie <br />

### MovieRating

`GET/api/movies/{movieId}/rating` - Get list of movie ratings for movie <br />
`GET /MovieRating/{movieId}/{movieRatingId}` - Get details of specified movie rating <br />
`POST /movies/{movieId}/comment` - Add movie rating for the movie <br />

## Technologies
* C#
* ASP.NET Core 5 Web API
* Entity Framework Core 5
* AutoMapper
* FluentValidation

## Prerequisites
- Visual Studio 2019 Community
- .NET Core 5 SDK

## Status
Project is finished at the moment.
