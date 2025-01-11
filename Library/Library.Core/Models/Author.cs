namespace Library.Core.Models;

public class Author
{
    public Author(Guid id, string firstName, string lastName, DateTime birthDate, string country)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Country = country;
    }
    
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime BirthDate { get; }
    public string? Country { get; }
}