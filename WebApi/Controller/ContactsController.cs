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
}
