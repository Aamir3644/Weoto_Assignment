# Assignment 
This is a web application built with a React frontend and a .NET Core Web API backend. The application includes user authentication and role-based authorization.

## Features  
- User Authentication (Sign Up, Sign In) 
- Role-Based Authorization (Admin and User roles) 
- Admin can add, view, update and delete products 
- Users can view products 

## Technologies Used  

-  **Frontend:** React, Axios 
- **Backend:** .NET Core, Entity Framework Core 
-  **Database:** SQL Server  
-  **Authentication:** JWT (JSON Web Tokens)

## API Endpoints

### User Authentication

-   **Register:** `POST  /api/User/register`
-   **Login:** `POST  /api/User/login`

### Product Management

-   **Get Products:** `GET  /api/Product`
-   **Add Product (Admin only):** `POST  /api/Product`
-   **Delete Product (Admin only):** `DELETE  /api/Product/{id}`
-   **Update Product (Admin only):** `PUT  /api/Product/{id}`

## Screenshot of UI

![Sign In](https://github.com/Aamir3644/Weoto_Assignment/assets/91945871/f2bbf4e9-8d57-401f-88ba-96ff11d348d4)


