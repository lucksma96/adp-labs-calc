using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Task = API.Models.Task;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("perform")]
        public async Task<ActionResult<TaskDTO>> Perform()
        {
            TaskDTO task = await _taskService.GetTaskFromAPI();
            _taskService.DoTask(task);
            await _taskService.PostTaskToAPI(task);

            return task;
        }
    }
}

