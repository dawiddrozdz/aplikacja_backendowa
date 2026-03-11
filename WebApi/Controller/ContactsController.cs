using Microsoft.AspNetCore.Mvc;
using AppCore.Interfaces;
using AppCore.Dto;

namespace WebApi.Controller;

[ApiController]
[Route("/api/contacts")]
public class ContactsController : ControllerBase
{
    private readonly IPersonService _service;

    public ContactsController(IPersonService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPersons(int page, int size)
    {
        return Ok(await _service.FindAllPeoplePagedAsync(page, size));
    }
}
