using System;
using System.Collections.Generic;
using System.Text;
using To_do_List;
using Xunit;
using System.Linq;

namespace ToDo.Tests
{
    public class ToDoViewModelTests
    {
        [Fact]
        public void ViewModel_Populate_Items_Correctly()
        {
            //Arrage
            ToDoViewModel viewModel = new ToDoViewModel();

            //Act


            //Assert
            Assert.Equal(4, viewModel.Items.Count);
        }

        [Fact]
        public void AddItemCommand_adds_new_item_to_the_list()
        {
            //Arrange
            ToDoViewModel viewModel = new ToDoViewModel();

            //Act
            viewModel.AddItemCommand.Execute(null);

            //Assert
            Assert.Equal(5, viewModel.Items.Count);
            Assert.Equal("ToDo Item 5", viewModel.Items.Last().Name);
        }

        [Fact]
        public void MarkAsCompletedCommand_Marks_item_as_completed_and_put_that_item_at_the_end_of_the_list()
        {
            //Arrange
            ToDoViewModel toDoViewModel = new ToDoViewModel();

            //Act
            toDoViewModel.MarkAsCompletedCommand.Execute(toDoViewModel.Items.First());

            //Assert
            Assert.True(toDoViewModel.Items.Last().IsCompleted);
        }

        [Fact]
        public void MarkAsCompletedCommand_updates_progress_and_header()
        {
            //Arrange
            var viewModel = new ToDoViewModel();

            //Act
            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            //Assert
            Assert.Equal($"1 tasks completed", viewModel.CompletedHeader);
            Assert.Equal(0.25, viewModel.CompletedProgress);
        }
    }
}
