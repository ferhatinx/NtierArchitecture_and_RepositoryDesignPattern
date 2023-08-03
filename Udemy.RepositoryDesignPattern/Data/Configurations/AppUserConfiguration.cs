using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.RepositoryDesignPattern.Data.Entities;

namespace Udemy.RepositoryDesignPattern.Data.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(x=>x.Name)
            .HasMaxLength(256)
            .IsRequired();
        builder.Property(x=>x.Surname)
            .HasMaxLength(256)
            .IsRequired();
        builder.HasMany(x => x.Accounts).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
                                
    }
}
