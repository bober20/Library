using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(b => b.BookId);
            builder.HasIndex(b => b.ISBN).IsUnique();
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.ImageUrl).IsRequired();
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.BorrowDate).IsRequired();
            builder.Property(b => b.DueDate).IsRequired();
            builder.Property(b => b.UserId).IsRequired(false); 

            builder.HasOne(b => b.Genre)
                .WithMany()
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.User)
                .WithMany(u => u.BorrowedBooks)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}