using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using todo_wpf.Models;

namespace todo_wpf.ViewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
        TodoTask task;

        public TodoViewModel(TodoTask t)
        {
            this.task = t;
        }

        //properties to be displayed
        public string TaskName
        {
            get
            {
                if (this.task == null) return "task not created";
                if (this.task.taskName == null) return "no task title set";
                return this.task.taskName;
            }
            set
            {
                this.task.taskName = value;
                RaisePropertyChanged();
                RaisePropertyChanged("About");
            }
        }
        public string DueDate //datetime
        {
            get
            {
                if (this.task == null) return "task not created";
                if (this.task.dueDate == null || this.task.dueDate == DateTime.Now.Date) return "no due date set";
                return this.task.dueDate.ToString();
            }
            set
            {
                int result;
                //check if input is an int
                try { result = Int32.Parse(value); }
                catch (FormatException) { return; };

                this.task.dueDate = task.dueDate.AddDays(result);
                RaisePropertyChanged();
                RaisePropertyChanged("About");
            }
        }
        public string IsOverdue //bool
        {
            get => this.task.isOverdue.ToString();
            set => this.task.isOverdue = !task.isOverdue;
        }
        public string IsComplete //bool
        {
            get => this.task.isComplete.ToString();
            set => this.task.isComplete = !task.isComplete;
        }
        public string IsAssigned //bool
        {
            get => this.task.isAssigned.ToString();
            set => this.task.isAssigned = !this.task.isAssigned;
        }
        public string Assignee //account obj
        {
            get
            {
                if (this.task == null) return "task not created";
                if (this.task.assignee == null) return "no account was assigned";
                return this.task.assignee.FirstName + this.task.assignee.LastName;

            }
            set
            {
                new Account(1, value, "last_name");
            }
        }
        
        public string About
        {
            get
            {
                if (this.task == null) return "task not created";
                return this.task.DisplayTask();
            }
        }

        //implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
