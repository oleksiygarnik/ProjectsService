using Agile.Domain;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        private const int ENTITY_COUNT = 50;

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var teams = GenerateRandomTeams();
            var users = GenerateRandomUsers(teams);
            var projects = GenerateRandomProjects(users, teams);
            var tasks = GenerateRandomTasks(users, projects);

            modelBuilder.Entity<Team>().HasData(teams);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<Task>().HasData(tasks);
        }

        public static ICollection<Team> GenerateRandomTeams()
        {
            int teamId = 1;

            var teamsFake = new Faker<Team>()
                .RuleFor(team => team.Id, f => teamId++)
                .RuleFor(team => team.Name, f => f.Random.Word())
                .RuleFor(team => team.CreatedAt, f => DateTime.Now);

            return teamsFake.Generate(ENTITY_COUNT);
        }

        public static ICollection<User> GenerateRandomUsers(ICollection<Team> teams)
        {
            int userId = 1;

            var usersFake = new Faker<User>()
                .RuleFor(user => user.Id, f => userId++)
                .RuleFor(user => user.FirstName, f => f.Person.FirstName)
                .RuleFor(user => user.LastName, f => f.Person.LastName)
                .RuleFor(user => user.Email, f => f.Person.Email)
                .RuleFor(user => user.Birthday, f => f.Person.DateOfBirth)
                .RuleFor(user => user.RegisteredAt, f => DateTime.Now)
                .RuleFor(user => user.TeamId, f => f.PickRandom(teams).Id);

            return usersFake.Generate(ENTITY_COUNT);
        }

        public static ICollection<Project> GenerateRandomProjects(ICollection<User> users, ICollection<Team> teams)
        {
            int projectId = 1;

            var projectsFake = new Faker<Project>()
                .RuleFor(project => project.Id, f => projectId++)
                .RuleFor(project => project.Name, f => f.Person.FullName)
                .RuleFor(project => project.Description, f => f.Person.FullName)
                .RuleFor(project => project.Deadline, f => f.Date.Soon())
                .RuleFor(project => project.Deadline, f => DateTime.Now)
                .RuleFor(project => project.AuthorId, f => f.PickRandom(users).Id)
                .RuleFor(project => project.TeamId, f => f.PickRandom(teams).Id);

            return projectsFake.Generate(ENTITY_COUNT);
        }

        public static ICollection<Task> GenerateRandomTasks(ICollection<User> users, ICollection<Project> projects)
        {
            int taskId = 1;

            var tasksFake = new Faker<Task>()
                .RuleFor(task => task.Id, f => taskId++)
                .RuleFor(task => task.Name, f => f.Person.FullName)
                .RuleFor(task => task.Description, f => f.Person.FullName)
                .RuleFor(task => task.CreatedAt, f => DateTime.Now)
                .RuleFor(task => task.FinishedAt, f => f.Date.Soon())
                .RuleFor(task => task.TaskState, f => f.PickRandom<TaskState>())
                .RuleFor(task => task.ProjectId, f => f.PickRandom(projects).Id)
                .RuleFor(task => task.PerformerId, f => f.PickRandom(users).Id);

            return tasksFake.Generate(ENTITY_COUNT);
        }

    }
}
