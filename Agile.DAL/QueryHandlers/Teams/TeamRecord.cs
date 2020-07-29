using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Infrastructure.QueryHandlers.Teams
{
    public class TeamRecord
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  IEnumerable<User> Members { get; set; }
    }

}
