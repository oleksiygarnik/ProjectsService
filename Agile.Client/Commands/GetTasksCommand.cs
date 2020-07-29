using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Client.Commands
{
    public class GetTasksCommand : ICommand
    {
        private readonly HttpClient _client;

        public GetTasksCommand(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task Execute()
        {
            var response = await _client.GetAsync($"api/tasks");

            var jsonTasks = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Domain.Task>>(jsonTasks);

            foreach (var task in tasks)
            {
                Console.WriteLine(task);
                Console.WriteLine();
            }
        }
    }
}
