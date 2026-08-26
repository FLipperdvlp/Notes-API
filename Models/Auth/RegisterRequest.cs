using System.ComponentModel.DataAnnotations;

namespace Notes_API.Models.Register;

public class RegisterRequest
{
    [Required]
    [MinLength(3, ErrorMessage = "minimum length is 3")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6, ErrorMessage = "minimum length is 6")]
    public string Password { get; set; } = string.Empty;
}