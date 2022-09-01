using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using API.Models;
using System.Text;
using API.Utils;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using Microsoft.Extensions.Logging;

namespace API.Services
{
    public class TaskService
    {
        private readonly ILogger<TaskService> _logger;

        private const string _baseAddress = "https://interview.adpeai.com/api/v1";
        private readonly IHttpClientFactory _clientFactory;

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public TaskService(ILogger<TaskService> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<TaskDTO> GetTaskFromAPI()
        {
            _logger.LogInformation("Getting new Task");

            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseAddress}/get-task");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseTask = await JsonSerializer.DeserializeAsync<TaskDTO>(responseStream, _jsonOptions);

            _logger.LogInformation($"Got Task {responseTask.Id}");
            _logger.LogDebug($"Task {responseTask.Id}: {responseTask.Operation} of {responseTask.Left} and {responseTask.Right}");

            return responseTask;
        }

        public async Task<string> PostTaskToAPI(TaskDTO task)
        {
            _logger.LogInformation($"Posting Task {task.Id}");

            var taskResult = new TaskResultDTO()
            {
                Id = task.Id,
                Result = task.Result
            };

            var stringContent = $@"{{""id"":""{taskResult.Id}"",""result"":{taskResult.Result}}}";

            var content = new StringContent(stringContent, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync($"{_baseAddress}/submit-task", content);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public TaskDTO DoTask(TaskDTO task)
        {
            var op = Enumeration.FromDisplayName<OperationType>(task.Operation);

            task.Result = op.DoOperation(task.Left, task.Right);

            _logger.LogInformation($"{task.Operation} of {task.Left} and {task.Right} resulted in {task.Result}");

            return task;
        }
    }
}

