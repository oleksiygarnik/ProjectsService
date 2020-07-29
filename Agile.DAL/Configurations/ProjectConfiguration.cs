using Agile.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.DAL.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects").HasKey(project => project.Id);

            builder.Property(project => project.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(project => project.Author)
                .WithMany(t => t.Projects)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(project => project.Team)
                .WithMany(t => t.Projects)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(project => project.Tasks)
                .WithOne(t => t.Project)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
