namespace Library.Core.Models;

public class Book
{
    public Guid Id { get; }
    public string ISBN { get; }
    public string Title { get; }
    public string ImageUrl { get; }
    public Genre Genre { get; }
    public string Description { get; }
    public Author Author { get; }
    public DateTime BorrowDate { get; }
    public DateTime DueDate { get; }
    
    public Book(Guid id, string isbn, string title, string imageUrl, Genre genre, string description, Author author, DateTime borrowDate, DateTime dueDate)
    {
        Id = id;
        ISBN = isbn;
        Title = title;
        ImageUrl = imageUrl;
        Genre = genre;
        Description = description;
        Author = author;
        BorrowDate = borrowDate;
        DueDate = dueDate;
    }
    
    public static (Book? book, string error) Create(Guid id, string isbn, string title, string imageUrl, Genre genre, string description, Author author, DateTime borrowDate, DateTime dueDate)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(isbn))
        {
            error = "ISBN is empty.";
        }
        else if (string.IsNullOrEmpty(title))
        {
            error = "Title is empty.";
        }
        else if (author == null)
        {
            error = "Author is null.";
        }
        else if (genre == null)
        {
            error = "Genre is null.";
        }

        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var book = new Book(id, isbn, title, imageUrl, genre, description, author, borrowDate, dueDate);
        
        return (book, error);
    }
}