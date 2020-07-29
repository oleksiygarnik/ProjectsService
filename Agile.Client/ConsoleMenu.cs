using Agile.Client.Commands;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Client
{
    public class ConsoleMenu : IMenu
    {
        public Dictionary<int, ICommand> Commands { get; set; } = new Dictionary<int, ICommand>();
        
        private readonly HttpClient _client;
        public ConsoleMenu(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.BaseAddress = new Uri("http://localhost:5000/");

            Commands.Add(1, new GetTasksCommand(_client));
            Commands.Add(2, new GetTaskByIdCommand(_client));
            Commands.Add(3, new AddTaskCommand(_client));
            Commands.Add(4, new DeleteTaskCommand(_client));
            Commands.Add(5, new StartTimerCommand(_client, new TimerService(1000)));
            Commands.Add(6, new ExitCommand());
        }

        public void Show()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Get all tasks");
            Console.WriteLine("2. Get task by Id");
            Console.WriteLine("3. Add task");
            Console.WriteLine("4. Remove vehicle");
            Console.WriteLine("5. Start timer");
            Console.WriteLine("6. Exit");
        }

        public async Task Run()
        {
            int choose;
            ICommand currentCommand = null;

            do
            {
                Show();

                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    if (Commands.TryGetValue(choose, out currentCommand))
                    {
                        await currentCommand.Execute();
                    }
                    else
                    {
                        Console.WriteLine("Repeat your choose");
                    }
                }
            }
            while (!(currentCommand is ExitCommand));
        }

    }
}
