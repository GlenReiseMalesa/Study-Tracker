# Study Tracker
## A web app built to help you track your studying and store the data locally,it is easy to use no-login

StudyTracker/
├── Models/
│   └── Subject.cs          # Database table definition
│   └── Assignment.cs
├── Data/
│   └── AppDbContext.cs      # Database connection and configuration
├── Services/
│   └── DatabaseService.cs   # Handles database persistence
├── Pages/
│   └── index.cshtml           # UI component
│   └── forms.cshtml
│   └── Privacy.cshtml
│   └── Error.cshtml
├── wwwroot/
│   └── index.html           # Contains JavaScript persistence code
└── Program.cs               # App startup configuration