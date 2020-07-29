using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{LastName} {FirstName}";

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime RegisteredAt { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public ICollection<Project> Projects { get; private set; }

        public ICollection<Task> Tasks { get; private set; }

        public User()
        {
            Projects = new List<Project>();
            Tasks = new List<Task>();
        }

        public void ChangeFirstname(string firstname)
        {
            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentException("message", nameof(firstname));

            FirstName = firstname;
        }

        public void ChangeLastname(string lastname)
        {
            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentException("message", nameof(lastname));

            LastName = lastname;
        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("message", nameof(email));

            Email = email;
        }

        public void ChangeBirthdayDate(DateTime birthdayDate) => Birthday = birthdayDate;

        public void ChangeRegisteredDate(DateTime registeredAt) => RegisteredAt = registeredAt;

        public void ChangeTeam(int teamId) => TeamId = teamId;
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(FullName).Append("\n");
            sb.AppendFormat("Email: {0}\n", Email);
            sb.AppendFormat("Birthday: {0}, RegisteredAt: {1}\n", Birthday, RegisteredAt);
            sb.AppendFormat("Team: {0}\n", Team?.Name);

            sb.Append("List of projects:\n");

            foreach (var project in Projects.Select((p, i) => new { p.Name, Id = ++i }))
                sb.AppendFormat("{0}. {1}\n", project.Id, project.Name);

            return sb.ToString();
        }
    }
}
