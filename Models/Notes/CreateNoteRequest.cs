using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Notes_API.Models;

public class CreateNoteRequest
{
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Content must be between 10 and 1000 characters.")]
    public string Content { get; set; } = string.Empty;
}