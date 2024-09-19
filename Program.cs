// See https://aka.ms/new-console-template for more information
//Console.ForegroundColor = ConsoleColor.Red;
using Expenses.Helper;
using Expenses.Repository;

BudgetRepo budgetRepo = new BudgetRepo();
ExpenseRepo expenseRepo = new ExpenseRepo();
CsvExport csvExport= new CsvExport();


if (args.Length == 0)
{
    CliCommands.ShowAllCommands();
    return;
}
var command = args[1].ToLower();

switch (command)
{
    case "add":
        if (args.Length >= 4 && decimal.TryParse(args[3],out decimal amount))
        {
            string description = args[2];
            string category = args.Length >=4 ? args[4] : "General";
            expenseRepo.AddTask(description,amount,category);
        }
        else
        {
            Console.WriteLine("A valid description, amount and category is needed.");
        }
        break;

    case "update":
        if (args.Length >= 4 && int.TryParse(args[2], out int id))
        {
           string description = args.Length > 3 ? args[3] : null;
           decimal money = Convert.ToDecimal(args.Length > 4 ? args[4] : null);
           string category = args.Length > 5 ? args[5] : null;
           expenseRepo.UpdateExpenses(id,description,money,category);
        } 
        else
        {
            Console.WriteLine("Update the required values");
        }   
        break;

    case "delete":
        if (args.Length > 1 && int.TryParse(args[2], out int deleteId))
        {
            expenseRepo.DeleteExpense(deleteId);
        }
        else
        {
            Console.WriteLine("Valid expenseId required");
        }
        break;    

    case "list":
        string categoryList = args.Length > 2 ? args[2].ToLower(): null;
        expenseRepo.PrintList(expenseRepo.GetExpenseByCategory(categoryList));
        // if (!string.IsNullOrEmpty(categoryList))
        // {
        //     expenseRepo.PrintList(expenseRepo.GetExpenseByCategory(categoryList));             
        // }
        // else
        // {
        //    expenseRepo.ListExpenses(categoryList);
        // }   
      break; 

    case "summary":
    int? month = null;
     if (args.Length > 2 && int.TryParse(args[2],out int monthValue))
     {
        month = monthValue;    
     } 
     expenseRepo.ShowSummary(month,budgetRepo);
     break;

    case "set-budget":
         decimal budget = Convert.ToDecimal(args[2]);
         budgetRepo.MonthlyBudget(budget);
         break;

    case "export":
     string toCsv = args[2];
     csvExport.ExportCsv(expenseRepo.GetAllExpenses(),toCsv);
     break;

    default:
       CliCommands.ShowAllCommands();
       break;
}   

     