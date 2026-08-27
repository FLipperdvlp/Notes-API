using Microsoft.EntityFrameworkCore;
using Notes_API.Database;
using Notes_API.Entities;
using Notes_API.Interfaces;

namespace Notes_API.Services;

public class NoteService(AppDbContext dbContext) : INoteService
{
    public async Task<IEnumerable<Note>> GetAllAsync(int userId)
    {
        return await dbContext.Notes
            .Where(n => n.UserId == userId)
            .ToListAsync();
    }

    public async Task<Note?> GetByIdAsync(int id, int userId)
    {
        return await dbContext.Notes
            .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);
    }

    public async Task<Note> CreateAsync(Note note)
    {
        note.CreatedAt = DateTime.UtcNow;

        dbContext.Notes.Add(note);

        await dbContext.SaveChangesAsync();

        return note;
    }

    public async Task<Note> EditAsync(int id, int userId, Note note)
    {
        var existingNote = await dbContext.Notes
            .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);

        if (existingNote is null)
            return null!;

        existingNote.Title = note.Title;
        existingNote.Content = note.Content;

        await dbContext.SaveChangesAsync();

        return existingNote;
    }

    public async Task<bool> DeleteAsync(int id, int userId)
    {
        var note = await dbContext.Notes
            .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);

        if (note is null)
            return false;

        dbContext.Notes.Remove(note);

        await dbContext.SaveChangesAsync();

        return true;
    }
}