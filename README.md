
# ASP.NET Core 9 MVC - User Registration System with Email Notification

This is an ASP.NET Core 9 MVC web application that allows users to register by submitting their name, email, and password. Upon successful registration, the system stores user data using Entity Framework Core and sends an automated email notification to the registered user.

---

## 🧩 Features

- User Registration Form (Name, Email, Password with Validation)
- Entity Framework Core for database interaction
- Email Notification upon successful registration using MailKit
- ASP.NET Core MVC Layout integrated with Bootstrap styling
- Environment variable used to securely store email credentials

---

## 🛠️ Technologies Used

- ASP.NET Core 9 MVC
- Entity Framework Core
- SQL Server
- MailKit (SMTP Email)
- Bootstrap 5 (UI)
- Environment Variables (Security)

---

## 🔧 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server (LocalDB or SQL Server Express)
- Optional: Visual Studio 2022+ or VS Code

---

## 🚀 How to Run the Project

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/UserRegistrationApp.git
cd UserRegistrationApp
```

### 2. Set the Environment Variable

Set the environment variable `appPass` with your email password for sending SMTP emails.

#### Windows (PowerShell):

```powershell
$env:appPass = "your-email-password"
```

#### Linux/macOS (bash):

```bash
export appPass="your-email-password"
```

Or use the .NET Secrets Manager for local development:

```bash
dotnet user-secrets init
dotnet user-secrets set "appPass" "your-email-password"
```

---

### 3. Configure SMTP Settings

In `appsettings.json`, configure the following section:

```json
"EmailSettings": {
  "From": "your-email@example.com",
  "SmtpServer": "smtp.yourprovider.com",
  "Port": "587",
  "Username": "your-email@example.com"
}
```

**Note:** Do not include the password here. It is fetched securely from the environment variable `appPass`.

---

### 4. Create and Apply Migrations

```bash
Add-Migration
Update-Database
```

This will create the database and `Users` table using Entity Framework Core.

---

### 5. Run the Application

```bash
dotnet run
```

Navigate to `https://localhost:5001/Account/Register` to access the registration form.

---

## 📂 Project Structure Overview

```
├── Controllers
│   └── AccountController.cs
├── Data
│   └── AppDbContext.cs
├── Models
│   ├── ApplicationUser.cs
│   └── RegisterViewModel.cs
├── Services
│   ├── IEmailService.cs
│   └── EmailService.cs
├── Views
│   └── Account
│       ├── Register.cshtml
│       └── RegisterSuccess.cshtml
│   └── Shared
│       └── _Layout.cshtml
├── wwwroot
│   └── css, js, lib (Bootstrap, site.css)
├── appsettings.json
└── Program.cs
```

---

## ✅ Validation Rules

- Name: Required, max length 100
- Email: Required, must be a valid email address
- Password: Required, minimum 6 characters
- Confirm Password: Must match Password

---

## 📧 Email Notification

Upon successful registration, a confirmation email is sent to the user using SMTP (MailKit). To ensure security, the email password is never stored in the source code.

---

## 🔒 Security Best Practices

- Passwords are not stored in `appsettings.json`
- Uses environment variables to protect email credentials

---

## 🧪 In Future I Will Do This Enhancements 

- Add Login & Authentication
- Integrate ASP.NET Identity
- Add email verification link
- Support third-party logins (Google, Facebook)
- Password hashing

---

## 🤝 Contributing

Feel free to fork this repository and submit pull requests. For any issues, open a GitHub issue.

---

## 🙋‍♂️ Author

Developed by [Mohammad Sohel Parves](https://github.com/SohelPerves)  

