using System.ComponentModel.DataAnnotations;

namespace Notes_API.Models.Login;

public class LoginRequest
{
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6, ErrorMessage = "minimum length is 6")]
    public string Password { get; set; } = string.Empty;
}