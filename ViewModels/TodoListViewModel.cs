using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyApp.Models;

namespace MyApp.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        public TodoListViewModel(IEnumerable<TodoItem> items)
        {
            Items = new ObservableCollection<TodoItem>(items);
        }
        
        public ObservableCollection<TodoItem> Items { get; }
    }
}