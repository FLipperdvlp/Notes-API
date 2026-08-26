using Notes_API.Entities;

namespace Notes_API.Interfaces;

public interface INoteService
{
    Task<IEnumerable<Note>> GetNotesByUserIdAsync(int userId);
    IEnumerable<Note> GetAll();
    Task<Note> CreateNote(int userId, string title, string content);
    Task<Note> EditNote(int noteId, int userId, string title, string content);
    Task<Note> ToggleNote(int noteId, int userId);
    Task<bool> DeleteNote(int noteId, int userId);
}
