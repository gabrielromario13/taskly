using ApplicationCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCore.Data.Mapping;

public class ProjectMap : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(u => u.Id);
        builder.Property(e => e.OwnerId).IsRequired();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.StartDate).IsRequired();
        builder.Property(e => e.EndDate).IsRequired(false);
        builder.Property(e => e.Status).IsRequired();
        builder.Property(e => e.Priority).IsRequired();
        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt).IsRequired(false);
        
        // builder
        //     .HasMany(c => c.Tasks)
        //     .WithOne()
        //     .HasForeignKey(c => c.UserId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}