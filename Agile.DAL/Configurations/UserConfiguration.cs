using Agile.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(user => user.Id);
            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(300);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(300);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(300);
            builder.Ignore(user => user.FullName);

            //builder.HasOne(user => user.Team)
            //    .WithMany(t => t.Members)
            //    .HasForeignKey(user => user.TeamId);

            builder.HasOne(user => user.Team)
                .WithMany(t => t.Members)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(user => user.Projects)
                .WithOne(p => p.Author)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(user => user.Tasks)
                .WithOne(t => t.Performer)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
