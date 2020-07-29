using Agile.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Agile.DAL.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks").HasKey(task => task.Id);

            builder.Property(task => task.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(t => t.Performer)
                .WithMany(t => t.Tasks)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Project)
                .WithMany(t => t.Tasks)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
