using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
        builder.HasKey(a => a.AuthorId);
        builder.Property(a => a.FirstName).IsRequired();
        builder.Property(a => a.LastName).IsRequired();
        builder.HasMany(a => a.Books).WithOne(b => b.Author);
    }
}