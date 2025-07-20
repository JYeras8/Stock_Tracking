# Stock Tracker

This repository contains a Windows Forms application for basic stock tracking.
The solution is built with **C#** using **.NET Framework 4.7.2** and
**Entity Framework 6.5.1**.

## Features

- Manage categories, products and customers
- Record sales transactions
- Alert when stock amounts drop below a threshold

## Building

1. Open `StockTracker.sln` in Visual Studio 2019 or later.
2. Restore NuGet packages if required (Entity Framework 6.5.1 is included in
   the `packages` directory).
3. Build and run the `StockTracker` project.

The application uses a connection string named `StockTrackingEntities` defined in
`StockTracker/App.config`. Update this connection string to point to your SQL
Server instance before running the application.

