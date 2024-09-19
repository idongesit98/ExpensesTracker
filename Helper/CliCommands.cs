using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Helper
{
    public class CliCommands
    {
        public static void ShowAllCommands()
        {
            Console.WriteLine("Available Commands");
            Console.WriteLine("expense add successfully \"Description\" --amount 20 --category \"drinks\"");
            Console.WriteLine("expense-tracker list");
            Console.WriteLine("expense-tracker summary");
            Console.WriteLine(" expense-tracker delete --id 1");
            Console.WriteLine("expense-tracker summary");
            Console.WriteLine("expense-tracker summary --month 8");

        }
    }
}