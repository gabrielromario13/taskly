using ApplicationCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCore.Data.Mapping;

public class UserProjectMap : IEntityTypeConfiguration<UserProject>
{
    public void Configure(EntityTypeBuilder<UserProject> builder)
    {
        builder.ToTable("UserProjects");
        
        builder
            .HasKey(up => new { up.UserId, up.ProjectId });
        
        builder
            .HasOne(up => up.User)
            .WithMany(u => u.UserProjects)
            .HasForeignKey(up => up.UserId);

        builder
            .HasOne(up => up.Project)
            .WithMany(p => p.ProjectUsers)
            .HasForeignKey(up => up.ProjectId);
    }
}