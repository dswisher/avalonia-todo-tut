﻿using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using MyApp.Models;
using MyApp.Services;
using ReactiveUI;

namespace MyApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase? content;
        
        public MainWindowViewModel(Database db)
        {
            Content = List = new TodoListViewModel(db.GetItems());
        }

        public ViewModelBase? Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
        
        public TodoListViewModel List { get; }

        public void AddItem()
        {
            var vm = new AddItemViewModel();

            Observable.Merge(
                    vm.Ok,
                    vm.Cancel.Select(_ => (TodoItem?)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        List.Items.Add(model);
                    }

                    Content = List;
                });

            Content = vm;
        }
    }
}
