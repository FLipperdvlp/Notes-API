using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Notes_API.Database;
using Notes_API.Entities;
using Notes_API.Interfaces;

namespace Notes_API.Services
{
    public class NoteService(AppDbContext dbContext) : INoteService
    {
        public async Task<IEnumerable<Note>> GetNotesByUserIdAsync(int userId)
        {
            return await dbContext.Notes.Where(t => t.UserId == userId).ToListAsync();
        }
        public async Task<Note> CreateNote(int userId, string title, string content)
        {
            var newNote = new Note
            {
                UserId = userId,
                Title = title,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            dbContext.Notes.Add(newNote);
            await dbContext.SaveChangesAsync();
            return newNote;
        }

        public async Task<Note> ToggleNote(int noteId, int userId)
        {
            var note = await dbContext.Notes.FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);
            if (note is null)
                return null!; 

            note.Title = note.Title == "Toggled" ? "Untoggled" : "Toggled";
            await dbContext.SaveChangesAsync();
            return note;
        }
        public async Task<bool> DeleteNote(int noteId, int userId)
        {
            var note = await dbContext.Notes.FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);
            if (note is null)
                return false;

            dbContext.Notes.Remove(note);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Note> EditNote( int noteId, int userId, string title, string content)
        {
            var note = await dbContext.Notes
                .FirstOrDefaultAsync( n => n.Id == noteId && n.UserId == userId );

            if (note is null)
                return null!;

            note.Title = title;
            note.Content = content;
            await dbContext.SaveChangesAsync();
            
            return note;
        }
    }
}