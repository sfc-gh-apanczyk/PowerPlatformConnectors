# SnowflakeTestApp.Tests

Integration tests for the Snowflake Test App that verify the endpoint's functionalities.

## Quick Start

### Method 1: Visual Studio (Recommended)

1. **Open Solution**
   - Launch Visual Studio
   - Open `dirs.sln` in `Snowflake V2` directory

2. **Start Application**
   - Run the application
   - Verify it's accessible at `https://localhost:44362`

3. **Run Tests**
   - Open **Test Explorer**
   - Click **Run All Tests** 
   - View results in Test Explorer

### Method 2: Command Line

1. **Start Application**
   ```bash
   # Build and run the app
   dotnet build
   dotnet run --project SnowflakeTestApp
   ```

2. **Run Tests** (in a new terminal)
   ```bash
   # Run all tests
   dotnet test
   
   # Or run specific test project
   dotnet test SnowflakeTestApp.Tests/SnowflakeTestApp.Tests.csproj
   ```

## Troubleshooting

- **Test fails**: Ensure SnowflakeTestApp is running at `https://localhost:44362`
- **Connection issues**: Check that the application started successfully without errors
