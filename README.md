# 🏥 Hospital Management System API

A robust RESTful API for managing hospital operations including patients, doctors, appointments, prescriptions, medications, and billing. Built using **.NET 8**, **Entity Framework Core**, and **JWT authentication**.

---

## 📌 Features

* 🔐 JWT-based Authentication & Role-based Authorization (Admin, Doctor, Patient)
* 🧑‍⚕️ Manage Doctors & Patients
* 🗕 Appointment Scheduling
* 💊 Prescription & Medication Management
* 💳 Billing & Payment Information
* 🛠️ Dependency Injection
* 📦 Clean Architecture with Repository Pattern
* 📄 Swagger UI for API Testing

---

## 🚀 Technologies Used

* .NET 8.0
* Entity Framework Core
* SQL Server
* JWT (JSON Web Tokens)
* Swagger / Swashbuckle
* AutoMapper
* ASP.NET Core Web API

---

## 🧑‍💻 Getting Started

### Prerequisites

* [.NET 8 SDK (8.0.406 or later)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* SQL Server (LocalDB or any SQL instance)
* Visual Studio or Visual Studio Code

### Clone the Repository

```bash
git clone https://github.com/your-username/HospitalManagementSystemAPI.git
cd HospitalManagementSystemAPI
```

### Configure the Database

Update the `appsettings.json` file:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=HospitalDB;Trusted_Connection=True;"
}
```

### Apply Migrations & Create the Database

```bash
dotnet ef database update
```

### Run the Application

```bash
dotnet run
```

Navigate to: `https://localhost:5001/swagger`

---

## 🔑 Roles

* **Admin**: Full control of the system
* **Doctor**: Manage appointments, prescriptions
* **Patient**: View own appointments, prescriptions, and bills

---

## 📂 Project Structure

```
├── Controllers/
├── Models/
├── DTOs/
├── Services/
├── Repositories/
├── Data/
├── Mappings/
├── Middleware/
└── Program.cs / Startup.cs
```

---

## 📊 Database Diagram

(Include a diagram image or link here if available)

---

## 🧪 Sample API Requests

### Login (JWT Token)

```http
POST /api/auth/login
Content-Type: application/json

{
  "username": "admin",
  "password": "admin123"
}
```

### Get All Patients

```http
GET /api/patients
Authorization: Bearer {your_token_here}
```

---

## ✅ To-Do

* ✅ Add Logging and Exception Handling
* 🚧 Implement Email Notifications
* 🚧 Add Unit & Integration Tests
* 🚧 Deploy to Azure/AWS

---

## 📃 License

This project is licensed under the MIT License.

---

## 🤝 Contributing

Pull requests are welcome! For major changes, please open an issue first to discuss what you’d like to change.

---

## 📬 Contact

**Author**: Saeed Mosaffer
📧 Email: [saeedmosaffer39@gmail.com](mailto:saeedmosaffer39@gmail.com)
🌐 LinkedIn: [linkedin.com/in/saeed-mosaffer](https://linkedin.com/in/saeed-mosaffer)
