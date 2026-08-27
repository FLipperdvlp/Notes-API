namespace Notes_API.DTOs;

public class CreateNoteDTO
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}