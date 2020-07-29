using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Domain
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }

        public DateTime CreatedAt { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public ICollection<Task> Tasks { get; private set; }

        public Project()
        {
            Tasks = new List<Task>();
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("message", nameof(name));

            Name = name;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("message", nameof(description));

            Description = description;
        }

        public void ChangeDeadline(DateTime deadline) => Deadline = deadline;

        public void ChangeAuthor(int authorId) => AuthorId = authorId;

        public void ChangeTeam(int teamId) => TeamId = teamId;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name).Append("\n");
            sb.AppendFormat("Description: {0}\n", Description);
            sb.AppendFormat("Deadline: {0}\n", Deadline);
            sb.AppendFormat("Author: {0}", Author.FullName);
            sb.AppendFormat("Team: {0}\n", Team.Name);

            sb.Append("Tasks:\n");
            foreach (var task in Tasks.Select((p, i) => new { p.Name, Id = ++i }))
                sb.AppendFormat("{0}. {1}\n", task.Id, task.Name);

            return sb.ToString();
        }
    }
}
