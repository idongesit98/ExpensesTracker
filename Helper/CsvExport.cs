using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Expenses.Model;

namespace Expenses.Helper
{
    public class CsvExport
    {
        public void ExportCsv(List<Expense> expenses, string filePath)
        {
            var csvForm = new List<string> {"Id, Description, Amount, Category, Datetime"};

            foreach (var expense in expenses)
            {
                csvForm.Add($"{expense.Id}, {expense.Description}, {expense.Amount}, {expense.Category}, {expense.CreatedAt}");                
            }
            File.WriteAllLines(filePath,csvForm);
            Console.WriteLine($"Exported expenses file to {filePath}");
        }
    }
}