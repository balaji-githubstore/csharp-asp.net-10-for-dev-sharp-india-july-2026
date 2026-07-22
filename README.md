# C# & ASP.NET Core 10 Training - Sharp Development Pvt Limited

Training repository covering modern C# features and ASP.NET Core 10 best practices.

---

## Projects Overview

### 1. **1CSharpProject** - C# Fundamentals
OOP (inheritance, abstraction, polymorphism), properties declaration, async/await, LINQ, IQueryable vs IEnumerable, generics, records, string extensions. Foundation for modern C# development.

### 2. **2EmployeeDashboard** - RESTful APIs
REST principles, DTOs, HTTP methods, API routing, HttpClient patterns. Employee management endpoints demonstrating basic CRUD operations.

### 3. **3BooksManagement** - API Development
Minimal APIs (MapGet, MapPost, MapPut, MapDelete), routing constraints, OpenAPI/Swagger integration, in-memory and distributed caching, IQueryable optimization, advanced CRUD patterns.

### 4. **4MiddlewareProject** - Middleware Architecture
Custom middleware (`app.Use()`), conditional middleware (`app.UseWhen()`), path-based branching (`app.Map()`), condition-based branching (`app.MapWhen()`), middleware ordering, API Key validation.

### 5. **5BookManagementWebApplicationMVC** - MVC Pattern
Controllers, Models, Views, IActionResult, ModelValidation (data annotations), ViewData, ViewBag, Razor syntax, _Layout, _ViewStart, Sections, authentication with cookies, claims-based security.

### 6. **6BookManagementWebAppRazor** - Razor Pages
@page directive, PageModel, properties for data binding, TempData, Session, Cookies, authentication, _ViewImports, logging with ILogger, Serilog integration.

### 7. **7EntityFrameworkWithoutMigration** - Database Context
EF Core configuration without migrations, DbContext setup, LINQ queries, direct database mapping, model-to-database relationship, SaveChangesAsync patterns.

### 8. **8DIConcepts** - Dependency Injection
DI container registration, service lifetimes (singleton, scoped, transient), dependency resolution, AddDbContext, AddServices patterns, constructor injection.

### 9. **9BooksManagement.Test** - Unit Testing
MSTest framework, Moq for mocking, test organization, unit test patterns, service layer testing, API endpoint testing.

---

## Key Learning Areas

✓ **C# Features**: OOP, Async/Await, LINQ, Records, Generics  
✓ **ASP.NET Core**: APIs, Middleware, Razor Pages, MVC  
✓ **Data Access**: Entity Framework Core, LINQ queries  
✓ **Architecture**: DI, Service Layer, SOLID principles  
✓ **Testing**: Unit Tests, Mocking, Test Coverage  

---

## Topics Covered

### C# Language Features
| Topic | Details | Project |
|-------|---------|---------|
| **OOP Principles** | Inheritance, abstraction, polymorphism, encapsulation | Project 1 |
| **Properties** | Auto-properties, property validation patterns | Project 1 |
| **Async/Await** | Asynchronous programming, Task handling | Project 1 |
| **LINQ** | Query syntax, method syntax, filtering, projections | Project 1, 7 |
| **IQueryable vs IEnumerable** | Query execution, deferred execution, ToQueryString() | Project 3, 7 |
| **Generics** | Generic types, type constraints, generic methods | Project 1 |
| **Records** | Immutable data types, record patterns | Project 1 |
| **String Extensions** | Custom extension methods | Project 1 |

### APIs & Routing
| Topic | Details | Project |
|-------|---------|---------|
| **REST Principles** | HTTP methods, resource design, status codes | Project 2, 3 |
| **Minimal APIs** | MapGet, MapPost, MapPut, MapDelete | Project 3 |
| **Route Constraints** | Type validation (`:int`, `:string`), parameter validation | Project 3 |
| **Route Parameters** | Default values, optional parameters, AsParameters | Project 3 |
| **OpenAPI/Swagger** | API documentation, `app.MapOpenApi()`, Swashbuckle | Project 3 |
| **DTOs** | Data Transfer Objects, request/response models | Project 2, 3 |
| **HttpClient** | HTTP request patterns, API consumption | Project 2, 3 |

### Middleware & Pipeline
| Topic | Details | Project |
|-------|---------|---------|
| **Middleware Types** | `app.Use()`, inline middleware patterns | Project 4 |
| **Conditional Middleware** | `app.UseWhen()` returns to main pipeline | Project 4 |
| **Path-Based Branching** | `app.Map()` URL-based routing | Project 4 |
| **Condition-Based Branching** | `app.MapWhen()` custom conditions | Project 4 |
| **Middleware Ordering** | Pipeline flow, request/response cycle | Project 4 |
| **HTTPS Redirection** | `app.UseHttpsRedirection()`, dev certificates | Project 4 |
| **Static Files** | `app.UseStaticFiles()`, wwwroot configuration | Project 4 |
| **Routing** | `app.UseRouting()`, endpoint mapping | Project 4 |

### MVC & Razor Pages
| Topic | Details | Project |
|-------|---------|---------|
| **MVC Architecture** | Controllers, Models, Views separation | Project 5 |
| **IActionResult** | Action result types, return values | Project 5 |
| **Razor Syntax** | View markup, C# expressions | Project 5, 6 |
| **@page Directive** | Critical for Razor Pages accessibility | Project 6 |
| **PageModel** | Page-focused model class | Project 6 |
| **_Layout & _ViewStart** | Master page patterns, layout setup | Project 5, 6 |
| **Sections** | `@RenderSection()`, section definition | Project 5, 6 |
| **_ViewImports** | Centralized imports, namespace shortcuts | Project 5, 6 |

### State Management & Data Passing
| Topic | Details | Project |
|-------|---------|---------|
| **ViewData** | Dictionary-based Controller-to-View data (current request) | Project 5 |
| **ViewBag** | Dynamic syntax for ViewData | Project 5 |
| **TempData** | Data persistence across redirects | Project 5, 6 |
| **Session** | Server-side user data storage | Project 6 |
| **Cookies** | Client-side persistent storage | Project 5, 6 |

### Authentication & Security
| Topic | Details | Project |
|-------|---------|---------|
| **Cookie Authentication** | Claims, ClaimsIdentity, ClaimsPrincipal | Project 5, 6 |
| **[Authorize] Attribute** | Authorization enforcement, role-based access | Project 5, 6 |
| **JWT Security** | Token-based authentication for APIs | Project 2, 3 |
| **API Key Validation** | Custom middleware for API security | Project 4 |
| **SignInAsync/SignOutAsync** | Authentication lifecycle | Project 6 |

### Data Access & Entity Framework
| Topic | Details | Project |
|-------|---------|---------|
| **DbContext Configuration** | Database connection, model mapping | Project 7 |
| **EF Core without Migrations** | Direct database mapping, existing databases | Project 7 |
| **EF Migrations** | `dotnet ef migrations add`, `dotnet ef database update` | Project 7 |
| **LINQ Queries** | Entity querying, FirstOrDefaultAsync, ToListAsync | Project 7 |
| **SaveChangesAsync** | Change tracking, persistence | Project 7 |

### Caching Strategies
| Topic | Details | Project |
|-------|---------|---------|
| **In-Memory Cache** | Fast local data access, IMemoryCache | Project 3 |
| **Distributed Cache** | Scalable caching, shared across servers | Project 3 |

### Dependency Injection
| Topic | Details | Project |
|-------|---------|---------|
| **Service Registration** | AddSingleton, AddScoped, AddTransient | Project 8 |
| **Service Lifetimes** | Singleton, Scoped, Transient patterns | Project 8 |
| **Constructor Injection** | DI through constructors, factory patterns | Project 8 |
| **AddDbContext** | Database context registration | Project 8 |

### Logging & Monitoring
| Topic | Details | Project |
|-------|---------|---------|
| **ILogger** | Built-in logging, ILogger injection | Project 6, 8 |
| **Log Levels** | Information, Warning, Error, Debug | Project 6 |
| **Console Provider** | Console output logging | Project 6 |
| **Serilog Integration** | Advanced logging, file sinks, rolling intervals | Project 6 |
| **EventLog** | Windows Event Log integration | Project 6 |

### Caching Strategies
| Concept | Project | Purpose |
|---------|---------|---------|
| **In-Memory Cache** | Project 3 (Books Management) | Fast access to frequently used data |
| **Distributed Cache** | Project 3 (Books Management) | Scalable caching across multiple servers |

### API Consumption
| Concept | Project | Purpose |
|---------|---------|---------|
| **HttpClient** | Project 2 & 3 (APIs) | Make HTTP requests to external APIs |

### Hosting & Deployment
| Topic | Details | Project |
|-------|---------|---------|
| **Kestrel Server** | Default ASP.NET Core server | Project 11 |
| **IIS Hosting** | Application Pool, reverse proxy setup | Project 11 |
| **ASP.NET Core Hosting Bundle** | Windows server deployment | Project 11 |
| **Folder Permissions** | IIS_IUSRS security configuration | Project 11 |
| **Custom Domain Binding** | hosts file, DNS configuration | Project 11 |
| **Multi-App Hosting** | Port management, multiple applications | Project 11 |
| **Application Publishing** | `dotnet publish -c Release` | Project 11 |

### Testing
| Topic | Details | Project |
|-------|---------|---------|
| **MSTest Framework** | Test organization, Assert methods | Project 9 |
| **Moq Library** | Mock objects, behavior verification | Project 9 |
| **Unit Tests** | Business logic testing, isolation | Project 9 |
| **API Testing** | Endpoint testing, response validation | Project 9 |
---
## Notes
For IIS debugging and resx generator, will share the code details during weekend. 

## Getting Started

1. Open `CSharpProject.slnx` in Visual Studio Code
2. Review projects in numerical order for progressive learning
3. Each project includes sample HTTP requests in `.http` files
4. Configuration via `appsettings.json` and `appsettings.Development.json`

---

**Trainer:** [Balaji Dinakaran](https://www.linkedin.com/in/balaji-dinakaran/)  
*Training conducted for Sharp Development Pvt Limited on Modern C# and ASP.NET Core 10*
