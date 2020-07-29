using Agile.Client.Extensions;
using Agile.Domain;
using Bogus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Client.Commands
{
    public class StartTimerCommand : ICommand
    {
        private readonly HttpClient _client;
        private readonly ITimerService _taskFinishedTimer;

        public StartTimerCommand(HttpClient client, ITimerService taskFinishedTimer)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _taskFinishedTimer = taskFinishedTimer ?? throw new ArgumentNullException(nameof(taskFinishedTimer));
            _taskFinishedTimer.Elapsed += _taskFinishedTimer_Elapsed;
        }

        private async void _taskFinishedTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var response = await _client.GetAsync($"api/tasks");

            var jsonTasks = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Domain.Task>>(jsonTasks);

            var tasksIds = tasks.Select(t => t.Id).ToArray();
            var taskId = tasksIds[new Random().Next(0, tasksIds.Length)];

            response = await _client.GetAsync($"api/tasks/{taskId}");

            var jsonTask = await response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<Domain.Task>(jsonTask);

            task.ProjectId = task.Project.Id;
            task.PerformerId = task.Performer.Id;

            task.TaskState = TaskState.Finished;

            response = await _client.PutAsJsonAsync("api/tasks", task);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"StatusCode: {response.StatusCode}, Id = {content}");
            }
            else
                throw new Exception("Unsuccessful operation");
        }

        public System.Threading.Tasks.Task Execute()
        {
            _taskFinishedTimer.Start();

            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
