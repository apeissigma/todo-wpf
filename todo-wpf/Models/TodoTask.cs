using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_wpf.Models
{
    public class TodoTask : IDueDate, IAssignable, ICompleteable
    {
        public string taskName { get; set; }

        //implement IDueDate
        public DateTime dueDate { get; set; }
        public bool isOverdue { get; set; }

        //implement ICompleteable
        public bool isComplete { get; set; }

        //implement IAssignable
        public bool isAssigned { get; set; }

        public Account assignee { get; set; }


        public TodoTask(string tName)
        {
            this.taskName = tName;
            this.dueDate = (DateTime.Now).AddDays(7);
            this.isComplete = false;
            this.isAssigned = false; 
        }
        public TodoTask(string tName, int daysUntilDue)
        {
            this.taskName = tName;
            this.dueDate = (DateTime.Now).AddDays(daysUntilDue); 
            this.isComplete = false;
            this.isAssigned = false;
        }
        public TodoTask(string tName, Account account)
        {
            this.taskName = tName;
            this.dueDate = (DateTime.Now).AddDays(7); 
            this.isComplete = false;
            this.isAssigned = true;
            this.assignee = account;
        }
        public TodoTask(string tName, int daysUntilDue, Account account)
        {
            this.taskName = tName;
            this.dueDate = (DateTime.Now).AddDays(daysUntilDue);
            this.isComplete = false;
            this.isAssigned = true;
            this.assignee = account;
        }


        //implement IDueDate
        public bool checkIfOverdue()
        {
            if (this.isOverdue) return true;
            else return false; 
        }

        //implement ICompleteable
        public void markComplete()
        {
            this.isComplete = true;
        }
        public void markIncomplete()
        {
            this.isComplete = false;
        }
        public bool checkIfComplete()
        {
            if (this.isComplete) return true;
            else return false;
        }

        //implement IAssignable
        public string assignTo(Account account)
        {
            if (this.isAssigned) return "This task has already been assigned.";
            this.assignee = account;
            this.isAssigned = true;
            return $"This task has been assigned to {account.FirstName} {account.LastName}.";
        }



        public string DisplayTask()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("-------------------------\n");
            sb.Append($"{this.taskName}\n");
            sb.Append("-------------------------\n");

            if (this.isComplete) sb.Append($"Status: Complete\n");
            else sb.Append($"Status: Not started\n");

            sb.Append($"Due Date: {dueDate} ");
            if (this.isOverdue) sb.Append("(Overdue)");

            if (this.isAssigned) sb.Append($"Assigned to: {this.assignee.FirstName} {this.assignee.LastName}");

            return sb.ToString();
        }

    }
}
