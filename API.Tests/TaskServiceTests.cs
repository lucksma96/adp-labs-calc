using System;
using API.Models;
using API.Services;
using Xunit;

namespace API.Tests
{
    public class TaskServiceTests
    {
        [Fact]
        public void GetTaskFromAPI_Should_ReturnTask()
        {
            var taskService = new TaskService();

            var task = taskService.GetTaskFromAPI();

            Assert.IsType<Task>(task);
            Assert.NotNull(task);
        }
    }
}

