using AppCore.Dto;
using AppCore.Interfaces;
using AppCore.Models;

namespace Infrastructure.Memory;

public class MemoryPersonService : IPersonService
{
    private readonly IContactUnitOfWork _unitOfWork;

    public MemoryPersonService(IContactUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResult<PersonDto>> FindAllPeoplePagedAsync(int page, int pageSize)
    {
        var people = await _unitOfWork.Persons.FindPagedAsync(page, pageSize);
        var items = people.Items.Select(p => PersonDto.FromEntity(p)).ToList();
        return new PagedResult<PersonDto>(items, people.TotalCount, people.Page, people.PageSize);
    }

    public async IAsyncEnumerable<PersonDto> FindPeopleFromCompanyAsync(Guid companyId)
    {
        var people = await _unitOfWork.Persons.GetByCompanyAsync(companyId);
        foreach (var p in people)
        {
            yield return PersonDto.FromEntity(p);
        }
    }

    public async IAsyncEnumerable<PersonDto> FindPeopleFromOrganizationAsync(Guid organizationId)
    {
        var people = await _unitOfWork.Persons.GetByOrganizationAsync(organizationId);
        foreach (var p in people)
        {
            yield return PersonDto.FromEntity(p);
        }
    }

    public Task<PersonDto?> FindByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PersonDto> CreateAsync(CreatePersonDto dto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, UpdatePersonDto dto)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddNoteAsync(Guid personId, string noteText)
    {
        throw new NotImplementedException();
    }

    public Task AddTagAsync(Guid personId, string tag)
    {
        throw new NotImplementedException();
    }
}
