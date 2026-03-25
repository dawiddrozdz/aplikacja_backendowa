using Microsoft.AspNetCore.Mvc;
using AppCore.Interfaces;
using AppCore.Dto;

namespace WebApi.Controller;

[ApiController]
[Route("/api/contacts")]
public class ContactsController(IPersonService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPersons(int page, int size)
    {
        return Ok(await service.FindAllPeoplePagedAsync(page, size));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPerson(Guid id)
    {
        var dto = await service.FindByIdAsync(id);
        if (dto == null)
            return NotFound();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonDto dto)
    {
        var result = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetPerson), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePersonDto dto)
    {
        var existingPerson = await service.FindByIdAsync(id);
        if (existingPerson == null)
            return NotFound();

        await service.UpdateAsync(id, dto);
        var updatedPerson = await service.FindByIdAsync(id);
        return Ok(updatedPerson);
    }

    [HttpPost("{contactId:guid}/notes")]
    [ProducesResponseType(typeof(NoteDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddNote(
        [FromRoute] Guid contactId,
        [FromBody] CreateNoteDto dto)
    {
        var note = await service.AddNoteToPerson(contactId, dto);
        return CreatedAtAction(
            nameof(GetNotes),
            new { contactId },
            NoteDto.FromEntity(note));
    }

    [HttpGet("{contactId:guid}/notes")]
    [ProducesResponseType(typeof(IEnumerable<NoteDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNotes([FromRoute] Guid contactId)
    {
        var person = await service.GetPerson(contactId);
        if (person == null)
            return NotFound();
        return Ok(person.Notes);
    }

    [HttpGet("{contactId:guid}/notes/{noteId:guid}")]
    [ProducesResponseType(typeof(NoteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNote([FromRoute] Guid contactId, [FromRoute] Guid noteId)
    {
        var person = await service.GetPerson(contactId);
        if (person == null)
            return NotFound();
        var note = person.Notes?.FirstOrDefault(n => n.Id == noteId);
        if (note == null)
            return NotFound();
        return Ok(note);
    }

    [HttpDelete("{contactId:guid}/notes/{noteId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveNote([FromRoute] Guid contactId, [FromRoute] Guid noteId)
    {
        await service.RemoveNoteFromPerson(contactId, noteId);
        return NoContent();
    }
}
