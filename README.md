# People Management System

This is people management system developed in C# using the .NET framework. It provides basic functionality to add, list, and load people data from a CSV file.

## Features

- **Add Person:** Allows adding a new person to the system, providing name, phone, and date of birth.
- **List People:** Lists all people registered in the system.
- **Load Data from CSV:** Allows loading people data from a CSV file, facilitating bulk import.

## Project Structure

```
PeopleManagementSystem/
│
├── Controllers/
│ ├── PessoaController.cs: API controller responsible for handling HTTP requests related to people.
│
├── Models/
│ ├── Pessoa.cs: Definition of the Person class, representing a person with name, phone, and date of birth.
│
├── Infra/
│ └── Data/
│ ├── PessoaRepository.cs: Class responsible for managing storage and access to people data.
│
├── Application/
│ └── ManagePessoa.cs: Class responsible for handling operations related to people data, such as reading CSV files.
│
├── Program.cs: Entry point of the application.
│
└── README.md: This file, providing information about the project.
```

## Setup

1. Make sure you have the .NET SDK installed on your development environment.
2. Clone the repository to your computer.
3. Open the project in your preferred IDE.
4. Check and adjust the correct path for the CSV file in the constructor of the `ManagePessoa` class in the `Program.cs` file.
5. Run the application.

## Usage

- Use an HTTP client (such as Postman or Insomnia) to send requests to the API.
- Use the `/api/Pessoa/add` endpoint to add a new person. Send a JSON object with the person's data (name, phone, and date of birth).
- Use the `/api/Pessoa/list` endpoint to list all registered people.
- Use the `/api/Pessoa/load-csv` endpoint to load people data from a CSV file. Provide the path to the CSV file as a parameter in the URL.


