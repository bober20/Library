namespace Library.Core.Models;

public class Genre
{
    public Guid Id { get; }
    public string Name { get; }
    
    public Genre(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}