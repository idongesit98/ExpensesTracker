using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expenses.Model;

namespace Expenses.Repository
{
    public class ExpenseRepo
    {
        private List<Expense> _expenses;

        public ExpenseRepo()
        {
            _expenses = ExpenseFileHandler.LoadExpenses(); 
        }

        public void AddTask(string description, decimal amount, string category = "General")
        {
            List<Expense> addExpense = _expenses;
            int newExpensesId = addExpense.Count > 0 ? addExpense[addExpense.Count - 1].Id + 1 : 1;
            Expense expense = new Expense
            {
                Id = newExpensesId,
                Description = description,
                Amount = amount,
                Category = category,
                CreatedAt = DateTime.Now
            };
            addExpense.Add(expense);
            ExpenseFileHandler.SaveExpenses(_expenses);
            Console.WriteLine($"Expense added successfully {expense.Id}");
            
        }

        public void UpdateExpenses(int id, string? newDescription,decimal newAmount,string? newCategory)
        {
            List<Expense> updateExpense = _expenses;
            Expense expense = updateExpense.Find(t => t.Id == id);
            if (expense != null)
            { 
                if (!string.IsNullOrEmpty(newDescription))
                {
                    expense.Description = newDescription;
                }          
                expense.Amount = newAmount;
                if (!string.IsNullOrEmpty(newCategory))
                {
                    expense.Category = newCategory;   
                } 
                ExpenseFileHandler.SaveExpenses(_expenses);
                Console.WriteLine($"Expense updated succesfully {expense.Id}");    
            }
        }

        public void DeleteExpense(int id)
        {
            List<Expense> expenses = _expenses;
            Expense expense = expenses.Find(t => t.Id == id);
            if (expense != null)
            {
                expenses.Remove(expense);
                ExpenseFileHandler.SaveExpenses(_expenses);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Expense deleted successfully {expense.Id}");
            }
            else
            {
                Console.WriteLine("Expense not found");
            }
        }

        public void ShowSummary(int? month = null, BudgetRepo budgetRepo = null)
        {
            var filteredExpenses = FilterExpensesByMonth(month);
            decimal total = CalculateTotalExpenses(filteredExpenses);
            DisplayTotalExpenses(month,total);
            budgetRepo?.CheckLimit(total);
        }

        private List<Expense> FilterExpensesByMonth(int? filteredmonth)
        {
            return filteredmonth.HasValue
            ? _expenses.Where(e => e.CreatedAt.Month == filteredmonth && e.CreatedAt.Year == DateTime.Now.Year).ToList()
            : _expenses;
        }

        private decimal CalculateTotalExpenses(List<Expense> expenses)
        {
            return expenses.Sum(e => e.Amount);
        }

        private void DisplayTotalExpenses(int? month, decimal? total = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string message = month.HasValue
            ? $"Total expenses for {DateTime.Now.ToString("MMMM")} : ${total}"
            : $"Total expenses: ${total}";
            Console.WriteLine(message);
        }

        public List<Expense> GetExpenseByCategory(string category)
        {
            var filteredCategory = 
            string.IsNullOrEmpty(category) ? _expenses
            : _expenses.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            return filteredCategory;   
        }

        //Used later
        public decimal TotalMonthlyExpenses(int month)
        {
            return _expenses.Where(e => e.CreatedAt.Month == month && e.CreatedAt.Year == DateTime.Now.Year).Sum(e => e.Amount);
        }

        public List<Expense> GetAllExpenses()
        {
            return _expenses;
        }

        public void PrintList(List<Expense> expenses)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\tID  \t\tDate  \t\tDescription  \t\tAmount  \tCategory");
             foreach (var expense in expenses)
            {
                Console.WriteLine($"\t{expense.Id}  \t{expense.CreatedAt}  \t{expense.Description}  \t\t ${expense.Amount} \t\t {expense.Category}");
            }
        }
    }
}