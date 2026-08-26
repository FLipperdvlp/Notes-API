using Microsoft.AspNetCore.Mvc;
using Notes_API.Interfaces;
using Notes_API.Models;
using Notes_API.Models.Request;
namespace Notes_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController(INoteService noteService) : Controller
{
    private int UserId => 1;

    [HttpGet] // ** Ger all notes
    public IActionResult GetNotes()
    {
        var notes = noteService.GetAll();

        return Ok(notes);
    }

    [HttpGet("{id}")] // ** Get note by id
    public async Task<IActionResult> GetNoteById(int id)
    {
        var note = noteService.GetAll().FirstOrDefault(n => n.Id == id);

        return note is null ? NotFound() : Ok(note);
    }

    [HttpGet("user/{userId}")] // ** Get notes by user id
    public async Task<IActionResult> GetNotesByUserId(int userId)
    {
        var notes = await noteService.GetNotesByUserIdAsync(userId);

        return Ok(notes);
    }

    [HttpPost] // ** Create note
    public async Task<IActionResult> CreateNote(CreateNoteRequest model)
    {
        var note = noteService.CreateNote(UserId, model.Title, model.Content);

        return Ok(note);
    }

    
}