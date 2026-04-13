# FormsApp_CS2_Arbitrage_And_Investment_Tracker
🚧 CS2 Trading Tracker & Analytics System (WIP)

⚠️ This project is currently under active development.
Features, database structure, and analytics logic may change frequently.

This is not a finished product yet — it is an evolving system focused on building a real-world trading analytics backend for CS2 items.

📦 CS2 Trading Tracker & Analytics System

A Code First .NET / EF Core application for tracking Counter-Strike 2 item trades, portfolio performance, and advanced analytics such as ROI, volume, and time-based returns.

📊 Overview

This project simulates a trading portfolio system for CS2 skins.

It tracks:

Item purchases and sales
Portfolio sheets (strategies / groups)
Skin metadata (type, condition, float, variant)
Profitability and performance metrics
Daily and global analytics

The system is built with a clean separation of concerns:

Raw data → Aggregated stats → Derived analytics
🏗️ Architecture
🟢 Core Entities
Entry

Represents a single trade transaction.

Buy / Sell prices
Dates
Status (Open / Closed / Cancelled)
Links to:
Sheet (portfolio)
SkinInfo (item instance)
SkinInfo

Represents the actual item instance, including:

Name (e.g. AK-47 | Redline)
Float value
Condition
Variant
Item type
Sheet

Represents a portfolio or strategy container.

Used to separate different trading approaches or experiments.

📈 Analytics System
📊 OverallStats (Global Performance)

Tracks total performance across all sheets:

Buy Volume (capital in)
Sell Volume (capital out)
Total Profit
Trade Count
Weighted ROI
Average Hold Time
Daily Return Efficiency

Derived values:

Total Volume = Buy + Sell
Profit Volume = Sell - Buy
📅 DailyStats

Tracks performance per day:

Daily profit
Daily volume
Trade count
ROI (computed from invested capital)
Time efficiency

Supports full recomputation from Entries for accuracy and rollback safety.

🧠 Key Design Principles
✔ Source of truth = Entries

All analytics are derived from raw trades.

✔ No stored duplicate calculations

Averages and derived values are computed, not stored.

✔ Rebuildable analytics

Stats can be fully recomputed from Entries at any time.

✔ Separation of concerns
Entry → transaction
SkinInfo → item data
Stats → analytics layer
⚙️ Technologies Used
.NET (C#)
Entity Framework Core (Code First)
SQL Server (or any EF Core provider)
LINQ for analytics computation
📦 EF Core Setup
Add Migration
dotnet ef migrations add InitialCreate
Update Database
dotnet ef database update
📊 Key Metrics Explained
ROI (Return on Investment)
ROI = TotalProfit / BuyVolume
Daily Return
DailyReturn = TotalProfit / TotalHoldDays
Volume
Volume = BuyVolume + SellVolume
🔁 Data Flow
Entry (Trade)
   ↓
DailyStats (per day aggregation)
   ↓
OverallStats (global aggregation)
🚧 Future Improvements
Unrealized profit tracking
Price history integration (Steam market API)
Advanced analytics (win rate, volatility)
UI dashboard (Blazor / React)
Authentication system (users & portfolios)
🧠 Learning Focus

This project demonstrates:

EF Core relationships (1:1, 1:n)
Database normalization vs analytics tradeoffs
Financial metric modeling
Aggregation design patterns
Clean architecture thinking
📌 Notes

This system prioritizes:

✔ correctness of financial logic
✔ consistency of derived metrics
✔ scalability of analytics layer
