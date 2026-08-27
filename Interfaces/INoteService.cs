using Notes_API.Entities;

namespace Notes_API.Interfaces;

public interface INoteService
{
    Task<IEnumerable<Note>> GetAllAsync(int userId);
    Task<Note?> GetByIdAsync(int id, int userId);
    Task<Note> CreateAsync(Note note);
    Task<Note> EditAsync(int id, int userId, Note note);
    Task<bool> DeleteAsync(int id, int userId);
}
