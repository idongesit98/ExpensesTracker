using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Expenses.Model;

namespace Expenses
{
    public static class ExpenseFileHandler
    {
        private static string filePath = "expenses.json";

        public static List<Expense> LoadExpenses()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Expense>>(json);
        
        }

        public static void SaveExpenses(List<Expense> expenses)
        {
            string json = JsonSerializer.Serialize(expenses);
            File.WriteAllText(filePath, json);
        }
    }
}