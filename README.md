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

## Screenshots of UI

###  **Sign In**

  
![Sign In](https://github.com/Aamir3644/Weoto_Assignment/assets/91945871/f2bbf4e9-8d57-401f-88ba-96ff11d348d4)

###  **Create Account**


![Create Account](https://github.com/Aamir3644/Weoto_Assignment/assets/91945871/da2f3d4e-887b-432a-b2f0-0fbc2b9e3ffc)

###  **Admin View to Product List Page**

  
![Admin Products Page](https://github.com/Aamir3644/Weoto_Assignment/assets/91945871/6f5f6b19-edf1-4a73-9471-0fa0043086f2)

###  **User View to Product List Page**

  
![User Products Page](https://github.com/Aamir3644/Weoto_Assignment/assets/91945871/5c870a7b-9240-43ee-8a91-646b07c09cf3)


