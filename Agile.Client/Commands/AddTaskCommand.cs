using Agile.Client.Extensions;
using Agile.Domain;
using Bogus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Client.Commands
{

    public class AddTaskCommand : ICommand
    {
        private readonly HttpClient _client;

        public AddTaskCommand(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async System.Threading.Tasks.Task Execute()
        {
            var rnd = new Random();
            var projectId = rnd.Next(50);
            var performerId = rnd.Next(50);

            var taskFake = new Faker<Domain.Task>()
                         .RuleFor(task => task.Name, f => f.Person.FullName)
                         .RuleFor(task => task.Description, f => f.Person.FullName)
                         .RuleFor(task => task.CreatedAt, f => DateTime.Now)
                         .RuleFor(task => task.FinishedAt, f => f.Date.Soon())
                         .RuleFor(task => task.TaskState, f => f.PickRandom<TaskState>())
                         .RuleFor(task => task.ProjectId, f => projectId)
                         .RuleFor(task => task.PerformerId, f => performerId);

            var task = taskFake.Generate();

            var response = await _client.PostAsJsonAsync("api/tasks", task);

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"StatusCode: {response.StatusCode}, Id = {content}");
        }
    }
}
