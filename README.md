AnyStor Inventory Management System

AnyStor is a comprehensive desktop inventory and sales management system built with Windows Forms (.NET) and SQL Server. It is designed to streamline business operations by providing real-time stock tracking, purchase/sales transaction management, user administration, and detailed reporting capabilities.

📋 Table of Contents

Features

Screenshots

Architecture

Technologies Used

Project Structure

Installation

Database Setup

Usage Guide

Contributing

Contact

✨ Features

📦 Inventory Management

Real-time Tracking: Stock levels update automatically after every purchase or sale.

Categorization: Organize products into custom categories.

Alerts: Stock level monitoring to prevent shortages.

Valuation: detailed reporting on current inventory value.

💳 Transaction Processing

Purchases: Manage incoming stock from dealers and suppliers.

Sales: Process customer transactions efficiently.

Calculations: Automatic calculation of sub-totals, discounts, and taxes.

Invoicing: Generate and print professional invoices using DGVPrinter.

👥 User Management

RBAC: Role-Based Access Control (Admin vs. Standard User).

Security: Secure authentication and authorization flows.

Audit: Activity logging to track user actions.

📊 Reporting & Analytics

Inventory Reports: Filter by category or product status.

Transaction History: Comprehensive logs of all buys and sells.

Summaries: Visual summaries of sales and purchase performance.

🔒 Security

SQL Injection Prevention: Utilizes parameterized queries.

Connection Pooling: Optimized database connections.

Validation: Robust input validation and error handling.

📷 Screenshots

Add screenshots of your application here

Login Screen

Dashboard





🏗️ Architecture

Three-Tier Architecture

The application follows a strict separation of concerns:

Presentation Layer (UI): Windows Forms handling user interaction.

Business Logic Layer (BLL): Classes handling calculations and logical validations.

Data Access Layer (DAL): Classes handling direct communication with SQL Server.

Database Schema

erDiagram
    USERS ||--o{ CATEGORIES : "creates"
    USERS ||--o{ PRODUCTS : "manages"
    USERS ||--o{ DEALERS_CUSTOMERS : "manages"
    USERS ||--o{ TRANSACTIONS : "processes"
    CATEGORIES ||--o{ PRODUCTS : "contains"
    PRODUCTS ||--o{ TRANSACTION_DETAILS : "listed_in"
    DEALERS_CUSTOMERS ||--o{ TRANSACTIONS : "participates"
    TRANSACTIONS ||--o{ TRANSACTION_DETAILS : "contains"


🔧 Technologies Used

Category

Technologies

Frontend

Windows Forms (WinForms), C#

Backend

.NET Framework 4.7.2, ADO.NET

Database

Microsoft SQL Server (2012+), T-SQL Stored Procedures

Libraries

DGVPrinter (Reporting/Invoicing)

Tools

Visual Studio 2019+, SQL Server Management Studio (SSMS), Git

📂 Project Structure

AnyStor-Inventory-Management/
│
├── AnyStor.BLL/                # Business Logic Layer
│   ├── categoriesBLL.cs
│   ├── productBLL.cs
│   └── ...
│
├── AnyStor.DAL/                # Data Access Layer
│   ├── categoriesDAL.cs
│   ├── productDAL.cs
│   └── ...
│
├── AnyStor.UI/                 # Presentation Layer (WinForms)
│   ├── frmLogin.cs
│   ├── frmAdminDashboard.cs
│   ├── frmInventory.cs
│   └── ...
│
├── Database/                   # SQL Scripts
│   ├── Scripts/
│   │   ├── CreateTables.sql
│   │   └── SeedData.sql
│   └── ERD_Diagram.png
│
├── Dependencies/               # External DLLs
│   └── DGVPrinter.dll
│
└── App.config                  # DB Connection Configuration


🚀 Installation

Prerequisites

.NET Framework 4.7.2 or higher

Microsoft SQL Server 2012 or higher

Visual Studio 2019 or higher

Steps

Clone the Repository

git clone [https://github.com/yourusername/AnyStor-Inventory-Management.git](https://github.com/yourusername/AnyStor-Inventory-Management.git)
cd AnyStor-Inventory-Management


Open Solution
Open AnyStor.sln in Visual Studio.

Restore Packages
Go to Tools → NuGet Package Manager → Package Manager Console and run:

Update-Package -reinstall


Build
Press Ctrl+Shift+B to build the solution.

🗄️ Database Setup

Create Database
Open SQL Server Management Studio (SSMS) and run:

CREATE DATABASE AnyStorDB;
GO
USE AnyStorDB;


Run Schema Scripts
Execute the script located at Database/Scripts/CreateTables.sql to generate tables and relationships.

Configure Connection String
Open App.config in the solution root and update the connection string with your local server details:

<connectionStrings>
    <add name="connstrng" 
         connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=AnyStorDB;Integrated Security=True;Pooling=true;Max Pool Size=100;Min Pool Size=10" 
         providerName="System.Data.SqlClient" />
</connectionStrings>


Seed Data (Optional)
To start with a default Admin account and sample products, run Database/Scripts/SeedData.sql.

📖 Usage Guide

1. First-Time Login

Use the default credentials (if Seed Data was used):

Username: admin

Password: admin123

User Type: Admin

2. Workflow

Define Master Data: Go to Admin Dashboard → Add Categories.

Add Partners: Add Dealers and Customers.

Stock Up: Go to Products to define items, then use Purchase Transactions to add stock quantity.

Sell: Go to Transactions → Sales to bill customers.

Audit: Use the Inventory tab to view real-time reports.

🤝 Contributing

Contributions are welcome!

Fork the Project

Create your Feature Branch (git checkout -b feature/AmazingFeature)

Commit your Changes (git commit -m 'Add some AmazingFeature')

Push to the Branch (git push origin feature/AmazingFeature)

Open a Pull Request

📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

📞 Contact

For any queries or support, please contact:

Email: pradeepmadushanka170@gmail.com

Project Link: https://github.com/Madhusanka1129/AnyStor-Inventory-Management
