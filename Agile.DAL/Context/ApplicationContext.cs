using Agile.DAL.Configurations;
using Agile.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Team> Teams { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Project> Projects { get; private set; }
        public DbSet<Task> Tasks { get; private set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);

        }
    }
}
