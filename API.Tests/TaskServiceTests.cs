using System;
using API.Models;
using API.Services;
using Xunit;

namespace API.Tests
{
    public class TaskServiceTests
    {
        [Fact(Skip = "needs HttpClient spy")]
        public void GetTaskFromAPI_Should_ReturnTask()
        {
            var taskService = new TaskService(null, null);

            var task = taskService.GetTaskFromAPI();

            Assert.IsType<Task>(task);
            Assert.NotNull(task);
        }

        [Fact]
        public void DoTask_Should_PerformAdditionOperation()
        {
            var task = new TaskDTO
            {
                Operation = "addition",
                Left = 1,
                Right = 1
            };

            var taskService = new TaskService(null, null);
            taskService.DoTask(task);

            Assert.Equal(2, task.Result);
        }

        [Fact]
        public void DoTask_Should_PerformSubtractionOperation()
        {
            var task = new TaskDTO
            {
                Operation = "subtraction",
                Left = 1,
                Right = 1
            };

            var taskService = new TaskService(null, null);
            taskService.DoTask(task);

            Assert.Equal(0, task.Result);
        }

        [Fact]
        public void DoTask_Should_PerformMultiplicationOperation()
        {
            var task = new TaskDTO
            {
                Operation = "multiplication",
                Left = 2,
                Right = 5
            };

            var taskService = new TaskService(null, null);
            taskService.DoTask(task);

            Assert.Equal(10, task.Result);
        }

        [Fact]
        public void DoTask_Should_PerformDivisionOperation()
        {
            var task = new TaskDTO
            {
                Operation = "division",
                Left = 10,
                Right = 2
            };

            var taskService = new TaskService(null, null);
            taskService.DoTask(task);

            Assert.Equal(5, task.Result);
        }

        [Fact]
        public void DoTask_Should_PerformRemainderOperation()
        {
            var task = new TaskDTO
            {
                Operation = "remainder",
                Left = 10,
                Right = 3
            };

            var taskService = new TaskService(null, null);
            taskService.DoTask(task);

            Assert.Equal(1, task.Result);
        }
    }
}

