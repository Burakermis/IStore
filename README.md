🛒 E-Commerce Web Application (IStore)

A modern e-commerce web application that delivers a complete online shopping experience.
Users can browse products, manage their shopping carts, and place orders, while administrators can manage products, categories, and orders through role-based authorization.

🚀 Features
👤 User Features

User registration and authentication

Browse products with detailed information

Add, update, or remove items from the shopping cart

Place orders and view order history

Role-based access control

🛠️ Admin Features

Admin authentication and authorization

Product and category management (CRUD)

Order management and status updates

User management and role assignment

🔐 Authentication & Authorization

The application implements secure authentication and authorization using built-in ASP.NET mechanisms:

Secure login and registration

Role-based access control (User / Admin)

Restricted access to admin-only functionalities

🧱 Application Architecture

The project follows a clean and modular architecture:

Separation of concerns (Controllers, Models, Views)

Maintainable and scalable structure

MVC design pattern

The overall request flow and system interactions are illustrated in the diagram above.

🧰 Tech Stack

Backend: C# / ASP.NET MVC

Frontend: HTML5, CSS3, JavaScript

Database: SQL Server

Authentication: ASP.NET Identity (Cookie-based authentication)

ORM: Entity Framework

⚙️ Setup & Installation
Prerequisites

Visual Studio 2022 or newer

.NET Framework or .NET SDK (depending on project version)

SQL Server (LocalDB or full version)

Clone the Repository

git clone https://github.com/Burakermis/IStore.git

Open the Project

Open the .sln file using Visual Studio

Restore NuGet packages if prompted

Configure Database

Update the connection string in Web.config or appsettings.json

Ensure SQL Server is running

Create the database and apply migrations if required

Run the Application

Press F5 or click Run in Visual Studio

The application will be available at
https://localhost:xxxx

🤝 Contributing

Contributions, issues, and feature requests are welcome.
Feel free to fork the repository and submit a pull request.

📄 License

This project is licensed under the MIT License.

⭐ If you like this project, don’t forget to star the repository!
