namespace Library.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<BookEntity> BorrowedBooks { get; set; } 
    }
}