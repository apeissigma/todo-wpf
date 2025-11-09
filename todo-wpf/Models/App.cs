using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_wpf.Models
{
    public class App
    {
        public List<TodoTask> Tasks;

        public App()
        {
            Tasks = new List<TodoTask>();
        }

        public void ViewTasks()
        {
            foreach (TodoTask task in Tasks)
            {
                task.DisplayTask(); 
            }
        }
    }
}
