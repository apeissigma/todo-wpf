using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace todo_wpf.Models
{
    public interface ICompleteable
    {
        bool isComplete { get; }

        void markComplete();
        void markIncomplete();

        bool checkIfComplete(); 
    }
}