
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NtierEntities.Domains;

namespace NtierDataAccess.Configurations;
public class WorkConfiguration : IEntityTypeConfiguration<Work>
{
    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Definition)
            .HasMaxLength(256)
            .IsRequired(true);
        builder.Property(x=>x.isCompleted).IsRequired(true);
            
    }
}
