using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Domain
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<User> Members { get; private set; }
        public ICollection<Project> Projects { get; private set; }

        public Team()
        {
            Members = new List<User>();
            Projects = new List<Project>();
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("message", nameof(name));

            Name = name;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}. {1} created at {2}\n", Id, Name, CreatedAt);
            sb.Append("Members:\n");

            foreach (var member in Members.Select((p, i) => new { p.FullName, Id = ++i }))
                sb.AppendFormat("{0}. {1}\n", member.Id, member.FullName);

            return sb.ToString();
        }
    }
}
