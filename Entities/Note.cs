namespace Notes_API.Entities;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;  
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}