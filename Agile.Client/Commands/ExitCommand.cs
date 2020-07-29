using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Client.Commands
{
    public class ExitCommand : ICommand
    {
        public Task Execute() => Task.CompletedTask;
    }
}
