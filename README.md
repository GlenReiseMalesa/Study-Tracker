# Study Tracker

## A web app built to help you track your studying and store the data locally,it is easy to use no-login

StudyTracker/
├── Models/
│   └── TaskItem.cs          # Database table definition
├── Data/
│   └── AppDbContext.cs      # Database connection and configuration
├── Services/
│   └── DatabaseService.cs   # Database initialization
│   └── TaskService.cs       # CRUD operations

├── Pages/
│   └── Home.razor           # UI component
│   └── Forms.razor
├── wwwroot/
│   └── index.html           # Contains JavaScript persistence code
└── Program.cs               # App startup configuration

