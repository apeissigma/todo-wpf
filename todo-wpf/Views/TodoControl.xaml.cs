using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using todo_wpf.Models;
using todo_wpf.ViewModels;

namespace todo_wpf.Views
{
    /// <summary>
    /// Interaction logic for TodoControl.xaml
    /// </summary>
    public partial class TodoControl : UserControl
    {
        TodoTask task;

        public TodoControl()
        {
            InitializeComponent();
            task = new TodoTask();
            this.DataContext = new TodoViewModel(task);
        }

        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}