# 🛍️ ShopEase — Blazor WebAssembly E-Commerce App

ShopEase is a modern, lightweight e-commerce web application built with **Blazor WebAssembly** and **ASP.NET Core**. It features secure user authentication, a persistent shopping cart, and a responsive UI — all powered by C# end-to-end.

---

## 🚀 Features

### 👤 User Authentication
- Secure login and registration using **ASP.NET Core Identity**
- Cookie-based authentication with persistent login state
- Custom `AuthenticationStateProvider` for client-server sync

### 🛒 Shopping Cart
- Cart logic managed via a shared `CartService`
- Cart data stored in browser `localStorage` for persistence
- Cart scoped per user — personalized experience
- Real-time updates across components

### 🧠 Authorization-Aware UI
- Conditional rendering with `AuthorizeView`
- Dynamic navigation and personalized greetings
- Protected routes and components

### 📦 Product Display
- Product cards with “Add to Cart” functionality
- Quantity management and item removal
- Cart summary with total price calculation

### 🔐 Security
- Input validation on all forms
- Protection against XSS and SQL injection via Razor and EF Core
- Secure cookie settings to prevent session hijacking

---

## 🧱 Architecture

### 🧩 Projects

| Project        | Description                                      |
|----------------|--------------------------------------------------|
| `Client`       | Blazor WebAssembly frontend                      |
| `Server`       | ASP.NET Core backend with Identity and APIs      |
| `Shared`       | Common models and services (`Product`, `CartService`, etc.) |

### 🛠️ Technologies

- **Blazor WebAssembly** — C# in the browser
- **ASP.NET Core** — Backend and Identity
- **Entity Framework Core** — Data access
- **Bootstrap** — UI styling
- **localStorage** — Cart persistence
- **Scoped Services** — State management

---

### Folder structure

These are the locations of the important files that were updated throughout this project.

```bash
ShopEase/
├── Client/                     # Blazor WebAssembly frontend
│   ├── wwwroot/               # Static assets (CSS, JS, images)
|   ├── Components/            # ProductCard component
│   ├── Pages/                 # Razor pages (Home, Login, Cart)
│   ├── Shared/                # Shared UI components (NavMenu, Header)
│   ├── Services/              # Frontend services (CartService, AuthService)
│   └── Program.cs             # Entry point for Blazor WebAssembly
│
├── Server/                     # ASP.NET Core backend
│   ├── Controllers/           # API endpoints
│   ├── Models/                # Identity and domain models
│   ├── Services/              # Backend services (e.g., ProductService)
│   ├── appsettings.json       # Configuration file
│   └── Program.cs             # Entry point for ASP.NET Core
│
├── Shared/                     # Shared models and logic
│   ├── Models/                # Product, CartItem, etc.
│   └── Services/              # Interfaces and shared service logic
│
├── README.md                   # Project documentation
└── ShopEase.sln                # Solution file
```

---

## 📦 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/shopease.git
   ```

2. Run the application:
    ```bash
     dotnet run --project Server 
     ```

3. Navigate to https://localhost:5001 in your browser.
