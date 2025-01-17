namespace Library.DataAccess.Entities
{
    public class BookEntity
    {
        public Guid BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public Guid GenreId { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public Guid? UserId { get; set; } 
        
        public GenreEntity Genre { get; set; }
        public AuthorEntity Author { get; set; }
        public UserEntity? User { get; set; }
    }
}