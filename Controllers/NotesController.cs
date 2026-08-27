using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes_API.DTOs;
using Notes_API.Entities;
using Notes_API.Interfaces;
using System.Security.Claims;

namespace Notes_API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotesController(INoteService noteService) : ControllerBase
{
    private int UserId =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<IActionResult> GetNotes()
    {
        var notes = await noteService.GetAllAsync(UserId);

        return Ok(notes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNoteById(int id)
    {
        var note = await noteService.GetByIdAsync(id, UserId);

        if (note is null)
            return NotFound();

        return Ok(note);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote(CreateNoteDTO model)
    {
        var note = await noteService.CreateAsync(new Note
        {
            UserId = UserId,
            Title = model.Title,
            Content = model.Content
        });

        return Ok(note);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, EditNoteDTO model)
    {
        var note = await noteService.EditAsync(
            id,
            UserId,
            new Note
            {
                Title = model.Title,
                Content = model.Content
            });

        if (note is null)
            return NotFound();

        return Ok(note);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var result = await noteService.DeleteAsync(id, UserId);

        if (!result)
            return NotFound();

        return NoContent();
    }
}