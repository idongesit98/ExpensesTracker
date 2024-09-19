# Expense Manager
This is a simple expense tracker application to manage your finances. The application should allow users to add, delete, view and summarises their expenses.
The sample solution for the [expense-tracker](https://roadmap.sh/projects/expense-tracker) challenge from [roadmap.sh](https://roadmap.sh/).

## Features

- **Add Expense**: Add an expense with a description, amount, and optional category.
- **Delete Expense**: Delete an expense by its ID.
- **List Expenses**: View all expenses or filter by category.
- **Expense Summary**: Get a summary of total expenses, including monthly summaries.
- **Set Budget**: Set a budget for the current month and receive a warning if exceeded.
- **CSV Export**: Allow users to export expenses to a CSV file.

## Prerequisites
- .NET SDK 8.0
- Any text editor or IDE (e.g., Visual Studio, VS Code)

## Installation

### Clone the repository

```bash
git clone -- https://github.com/idongesit98/ExpensesTracker.git
cd [`Your Project directory`]

```
### Build the project

```bash
dotnet build
```
### Usage
```
## Usage

### Add an Expense

```bash
dotnet run expenses-tracker add --description "Dinner" --amount 20 --category "Food"
Expense added successfully (ID: 1)
```
### List All Expenses

```bash
dotnet run expenses-tracker list
```
ID   Date       Description   Amount  Category
1    2024-19-01  Lunch         $20     Food
```
```
- **By category**
dotnet run expenses-tracker list "food"
```
```
ID   Date       Description   Amount  Category
1    2024-19-01  Dinner         $20    Food

```
### Delete an Expense

```bash
dotnet run expenses-tracker delete --id 1
Expense deleted successfully ID: --id
```
### Get a Summary of Total Expenses

```bash
dotnet run expenses-tracker summary
Total expenses : $40
```
- **By Specific Month**
dotnet run expenses-tracker summary 9
```
```
Total expenses for September: $40
```
### Set a Monthly Budget

```bash
dotnet run expenses-tracker set-budget --amount 500
Budget set for the current month: $20
```

### Export Expenses to CSV

```bash
dotnet run expenses-tracker export --file expenses.csv
```
### Sample Json File
[{
    "Id":1,
    "Description":"Dinner",
    "Amount":20,
    "Category":"food",
    "CreatedAt":"2024-09-18T21:36:47.5265706+01:00"
}]


