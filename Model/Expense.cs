using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Model
{
    public class Expense
    {
        public int Id {get; set;}
        public string Description {get; set;} = string.Empty;
        public decimal Amount {get; set;}
        public string Category {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.Now;    
    }
}