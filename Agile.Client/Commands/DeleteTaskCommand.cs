using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Client.Commands
{
    public class DeleteTaskCommand : ICommand
    {
        private readonly HttpClient _client;

        public DeleteTaskCommand(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task Execute()
        {
            int taskId = InputValidator.InputIntegerValue("Enter taskId:");

            var response = await _client.DeleteAsync($"api/tasks/{taskId}");

            if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                Console.WriteLine("Successfully deleted");
            else
                Console.WriteLine("No Content");
        }
    }
}
