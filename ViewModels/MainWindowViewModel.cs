using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Services;
using ReactiveUI;

namespace MyApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase content;
        
        public MainWindowViewModel(Database db)
        {
            List = new TodoListViewModel(db.GetItems());
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
        
        public TodoListViewModel List { get; }

        public void AddItem()
        {
            Content = new AddItemViewModel();
        }
    }
}
