namespace Library.DataAccess.Entities;

public class AuthorEntity
{
    public Guid AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Country { get; set; }
    public List<BookEntity> Books { get; set; }
}