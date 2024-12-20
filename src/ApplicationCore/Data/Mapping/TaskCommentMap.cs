﻿using ApplicationCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCore.Data.Mapping;

public class TaskCommentMap : IEntityTypeConfiguration<TaskComment>
{
    public void Configure(EntityTypeBuilder<TaskComment> builder)
    {
        builder.ToTable("TaskComments");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.TaskId).IsRequired();
        builder.Property(u => u.UserId).IsRequired();
        builder.Property(e => e.Content).IsRequired().HasMaxLength(100);
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired(false);
    }
}