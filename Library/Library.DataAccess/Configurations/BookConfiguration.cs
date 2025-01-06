using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(b => b.BookId);
        builder.Property(b => b.ISBN).IsRequired();
        builder.Property(b => b.Title).IsRequired();
        builder.Property(b => b.ImageUrl).IsRequired();
        builder.Property(b => b.Description).IsRequired();
        builder.Property(b => b.BorrowDate).IsRequired();
        builder.Property(b => b.DueDate).IsRequired();
        builder.HasOne(b => b.Genre)
            .WithMany()
            .HasForeignKey(b => b.GenreId);
        builder.HasOne(b => b.Author)
            .WithMany()
            .HasForeignKey(b => b.AuthorId);
    }
}