# Counter-Strike 2 Arbitrage and Investment Tracker

![.NET](https://img.shields.io/badge/.NET-10-purple)
![C#](https://img.shields.io/badge/C%23-blueviolet)
![License](https://img.shields.io/badge/License-MIT-green)

The Counter-Strike 2 Arbitrage and Investment Tracker is a personal project designed to help CS2 traders and investors manage and monitor their skin portfolios.

The application allows users to track the value of their inventories, monitor trades, and analyze portfolio performance using live market data from the CSFloat API. It also includes a built-in currency converter, supporting **CNY (Chinese Yuan)**, **EUR (Euro)**, and **USD (US Dollar)**, making it easier to compare prices across different marketplaces.

Although the project is still under active development, it already includes a functional graphical user interface and core portfolio tracking features. Additional functionality and improvements are planned as development continues.

## Features

- 📈 Track your CS2 skin trades
- 💰 Monitor profits and losses
- 🔄 Import live market data using the **CSFloat API**
- 📊 View trade history
- 🖥️ Modern WinForms user interface
- 💾 Local database for storing portfolio data
- 💵 Currency converter **(ExchangeRate-API)**

## Screenshots
<img width="1048" height="600" alt="TrackerPreview" src="https://github.com/user-attachments/assets/b4c0c42e-81ac-4202-a159-61e2e5f72f66" />
<img width="957" height="572" alt="Screenshot_1" src="https://github.com/user-attachments/assets/98efd904-9170-4e2b-a7ee-a09fc4acc5a7" />
<img width="976" height="593" alt="Screenshot_3" src="https://github.com/user-attachments/assets/0be60bcd-fb9c-4e38-942a-0cd0b8e06004" />
<img width="289" height="532" alt="Screenshot_2" src="https://github.com/user-attachments/assets/ec5ac8f4-3c08-41c4-a875-1079d407df5e" />

## Configuration

To enable live price updates, you will need a **CSFloat API key** and a local SQL Server database.

### 1. Obtain a CSFloat API key

Create a CSFloat account and generate an API key.

### 2. Configure `appsettings.json`

Update your `appsettings.json` file with your SQL Server connection string and CSFloat API key.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  },
  "CsFloat": {
    "ApiKey": "YOUR_CSFLOAT_API_KEY"
  }
}
```

### 3. Create the database

Apply the Entity Framework Core migrations to create the local database.

```bash
dotnet ef database update
```

After completing these steps, the application will be able to retrieve live market prices from the CSFloat API and store portfolio data in your local SQL Server database.

## Technologies

- C#
- .NET 10
- Windows Forms (WinForms)
- Entity Framework Core
- SQL Server
- CSFloat API
- ExchangeRate-API

