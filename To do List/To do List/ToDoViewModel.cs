using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace To_do_List
{
    public class ToDoViewModel : BindableObject
    {
        private ToDoItem _selectedItem;
        private string _completedHeader;
        private double _completedProgress;

        public ObservableCollection<ToDoItem> Items { get; set; }
        public string PageTitle { get; set; }
        public ToDoItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged(nameof(PageTitle));
            }
        }

        public string CompletedHeader { get => _completedHeader; set { _completedHeader = value; OnPropertyChanged(); } }
        public double CompletedProgress { get => _completedProgress; set { _completedProgress = value; OnPropertyChanged(); } }

        public ICommand AddItemCommand => new Command(() => AddNewItem());
        public ICommand MarkAsCompletedCommand => new Command<ToDoItem>(MarkAsCompleted);

        public event EventHandler<double> UpdateProgressBar;

        public ToDoViewModel()
        {
            Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
            CalculateCompletedHeaders();
        }
        private void AddNewItem()
        {
            Items.Add(new ToDoItem { Name = $"ToDo Item {Items.Count + 1}" });
            CalculateCompletedHeaders();
        }
        private void MarkAsCompleted(ToDoItem item)
        {
            item.IsCompleted = true;
            Items.Remove(item);
            Items.Add(item);
            CalculateCompletedHeaders();
        }

        private void CalculateCompletedHeaders()
        {
            int tasksCompleted = Items.Count(item => item.IsCompleted);
            CompletedHeader = $"{tasksCompleted} tasks completed";
            CompletedProgress = (double)tasksCompleted / Items.Count;
            UpdateProgressBar?.Invoke(this, CompletedProgress);
        }
    }
}