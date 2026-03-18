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

    public async Task<PersonDto?> FindByIdAsync(Guid id)
    {
        var person = await _unitOfWork.Persons.FindByIdAsync(id);
        return person != null ? PersonDto.FromEntity(person) : null;
    }

    public async Task<PersonDto> CreateAsync(CreatePersonDto dto)
    {
        var entity = dto.ToEntity(Guid.NewGuid());
        entity = await _unitOfWork.Persons.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return PersonDto.FromEntity(entity);
    }

    public async Task UpdateAsync(Guid id, UpdatePersonDto dto)
    {
        var person = await _unitOfWork.Persons.FindByIdAsync(id);
        if (person == null)
            throw new KeyNotFoundException($"Osoba o ID {id} nie istnieje.");

        // Mapowanie zmian z dto do entity
        if (dto.FirstName is not null)
            person.FirstName = dto.FirstName;
        if (dto.LastName is not null)
            person.LastName = dto.LastName;
        if (dto.Email is not null)
            person.Email = dto.Email;
        if (dto.Phone is not null)
            person.Phone = dto.Phone;
        if (dto.BirthDate.HasValue)
            person.BirthDate = dto.BirthDate.Value;
        if (dto.Gender.HasValue)
            person.Gender = dto.Gender.Value;
        if (dto.Position is not null)
            person.Position = dto.Position;
        if (dto.EmployerId.HasValue)
            person.Employer = dto.EmployerId.ToString();
        if (dto.Status.HasValue)
            person.ContactStatus = dto.Status.Value;
        if (dto.Address is not null)
        {
            person.Address = new AppCore.Models.Address
            {
                Id = person.Address?.Id ?? Guid.NewGuid(),
                Street = dto.Address.Street,
                City = dto.Address.City,
                PostalCode = dto.Address.PostalCode,
                Country = dto.Address.Country,
                AddressType = dto.Address.Type
            };
        }

        await _unitOfWork.Persons.UpdateAsync(person);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var person = await _unitOfWork.Persons.FindByIdAsync(id);
        if (person == null)
            throw new KeyNotFoundException($"Osoba o ID {id} nie istnieje.");

        await _unitOfWork.Persons.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
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
