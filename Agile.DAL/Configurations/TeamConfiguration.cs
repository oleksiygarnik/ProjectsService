using Agile.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.DAL.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams").HasKey(team => team.Id);

            builder.Property(team => team.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(t => t.Projects)
                .WithOne(p => p.Team)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Members)
                .WithOne(m => m.Team)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
