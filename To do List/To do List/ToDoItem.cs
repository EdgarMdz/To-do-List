using System;
using System.Collections.Generic;
using System.Text;

namespace To_do_List
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public static IEnumerable<ToDoItem> GetToDoItems()
        => new List<ToDoItem>
            {
                new ToDoItem{Name="Go to the gym"},
                new ToDoItem{Name = "Tak a nap"},
                new ToDoItem{Name ="Go to work"},
                new ToDoItem{Name ="Work on the project"}
            };
    }
}