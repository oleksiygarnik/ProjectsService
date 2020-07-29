using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Client.Commands
{
    public class GetTaskByIdCommand : ICommand
    {
        private readonly HttpClient _client;

        public GetTaskByIdCommand(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task Execute()
        {
            int taskId = InputValidator.InputIntegerValue("Enter taskId:");

            var response = await _client.GetAsync($"api/tasks/{taskId}");

            if(response.StatusCode != HttpStatusCode.OK)
                Console.WriteLine($"Not found task with id = {taskId}");
            else
            {
                var jsonTask = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<Domain.Task>(jsonTask);

                Console.WriteLine(task);
            }
      
        }
    }
}
