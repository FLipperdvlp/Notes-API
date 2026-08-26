namespace Notes_API.Entities;

public class Note
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = null!;  
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsPinned { get; set; } = false;
    public User? User { get; set; }
}