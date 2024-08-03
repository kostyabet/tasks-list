using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasksList.DataAccess.Entities;

namespace TasksList.DataAccess.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(b => b.Title)
            .HasMaxLength(Core.Models.Task.MAX_TITLE_LENGTH)
            .IsRequired();
        builder.Property(b => b.Description)
            .HasMaxLength(Core.Models.Task.MAX_DESCRIPTION_LENGTH)
            .IsRequired();
    }
}