using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.RepositoryDesignPattern.Data.Entities;

namespace Udemy.RepositoryDesignPattern.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(x=>x.Balance)
            .HasColumnType("decimal(18,4)")
            .IsRequired();
        builder.Property(x => x.AccountNumber)
            .IsRequired();
    }
}
