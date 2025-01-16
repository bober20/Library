using System.ComponentModel.DataAnnotations;

namespace Library.API.Requests;

public class UserRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}