namespace Library.Core.Models;

public class Genre
{
    public Guid Id { get; }
    public string Name { get; }
    
    private Genre(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public static (Genre genre, string error) Create(Guid id, string name)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name))
        {
            error = "Name is empty.";
        }

        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var genre = new Genre(id, name);
        
        return (genre, error);
    }
}