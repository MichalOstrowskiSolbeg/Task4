# Task 4 - "Reading List"

ASP .NET Core MVC application "Reading List". 
Application allows you to create your own reading list from available books in database. 
You can add book to your list, set category and mark(using switch button) if you have already read it.




## Features

- CRUD on BookCategory table
- See all books
- Reorder BookCategory items position by up and down arrows
- Change IsRead value using switch button

## Documentation

Project contains of 4 layers (Repository, Service, Api, UI). 
Each layer is a different project. Project uses EF to connect to MsSql database. 
Models were created by scaffolding DbContext. 
Validation was made with FluentValidation library which could help me separate request objects from validation.
I'm using AutoMapper to map DTOs


## How to run

- type 'cd ui' in Powershell terminal
- type 'npm start' to run React.js application
- run ASP .Net application

![first step](https://github.com/MichalOstrowskiSolbeg/Task4/blob/main/screenshot1.png?raw=true)

![second step](https://github.com/MichalOstrowskiSolbeg/Task4/blob/main/screenshot2.png?raw=true)

![third step](https://github.com/MichalOstrowskiSolbeg/Task4/blob/main/screenshot3.png?raw=true)
## Database

Database is hosted on https://freeasphosting.net/

![Database](https://github.com/MichalOstrowskiSolbeg/Task4/blob/main/Task4-DBstructure.png?raw=true)

