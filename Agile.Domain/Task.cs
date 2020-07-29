using Domain;
using System;
using System.Text;

namespace Agile.Domain
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public TaskState TaskState { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int PerformerId { get; set; }
        public User Performer { get; set; }

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

        public void ChangeFinishedDate(DateTime finishedAt) => FinishedAt = finishedAt;

        public void ChangeTaskState(TaskState state) => TaskState = state;

        public void ChangeProject(int projectId) => ProjectId = projectId;

        public void ChangePerformer(int performerId) => PerformerId = performerId;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Name).Append("\n");
            sb.AppendFormat("Description: {0}\n", Description);
            sb.AppendFormat("FinishedAt: {0}\n", FinishedAt);
            sb.AppendFormat("TaskState: {0}\n", TaskState);
            sb.AppendFormat("Performer: {0}", Performer.FullName);
            sb.AppendFormat("Project: {0}", Project.Name);

            return sb.ToString();
        }
    }
}
