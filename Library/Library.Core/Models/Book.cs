namespace Library.Core.Models;

public class Book
{
    public Guid Id { get; }
    public string ISBN { get; }
    public string Title { get; }
    public string ImageUrl { get; }
    public Guid GenreId { get; }
    public string Description { get; }
    public Guid AuthorId { get; }
    public DateTime BorrowDate { get; }
    public DateTime DueDate { get; }
    public Guid? UserId { get; }
    
    public Book(Guid id, string isbn, string title, string imageUrl, Guid genreId, string description, Guid authorId, 
        DateTime borrowDate, DateTime dueDate, Guid? userId)
    {
        Id = id;
        ISBN = isbn;
        Title = title;
        ImageUrl = imageUrl;
        GenreId = genreId;
        Description = description;
        AuthorId = authorId;
        BorrowDate = borrowDate;
        DueDate = dueDate;
        UserId = userId;
    }
}