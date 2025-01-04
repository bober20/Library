namespace Library.Core.Models;

public class Author
{
    private Author(Guid id, string firstName, string lastName, DateTime birthDate, string country, List<Book> books)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Country = country;
        Books = books;
    }
    
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime BirthDate { get; }
    public string? Country { get; }
    public List<Book> Books { get; } 

    public static (Author author, string error) Create(Guid id, string firstName, string lastName, DateTime birthDate, string country, List<Book> books)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
        {
            error = "First name and/or last name are both empty.";
        }
        
        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }
        
        var author = new Author(id, firstName, lastName, birthDate, country, books);
        
        return (author, error);
    }
}