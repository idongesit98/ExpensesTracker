using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Repository
{
    public class BudgetRepo
    {
        private decimal _monthlyBudget;
        public void MonthlyBudget(decimal budget)
        {
            _monthlyBudget = budget;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Monthly budget has been capped at: ${budget}");
        }

        public void CheckLimit(decimal monthlyExpenses)
        {
            if ( monthlyExpenses > _monthlyBudget)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Warning!! you have exceed your monthly limit ${monthlyExpenses - _monthlyBudget}");
            }
        }
    }
}