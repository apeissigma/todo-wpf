using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace todo_wpf.Models
{
    public interface IDueDate
    {
        DateTime dueDate { get; }
        bool isOverdue { get; }

        bool checkIfOverdue(); 
    }
}