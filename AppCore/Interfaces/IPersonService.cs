using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppCore.Dto;

namespace AppCore.Interfaces;

public interface IPersonService
{
    Task<PagedResult<PersonDto>> FindAllPeoplePagedAsync(int page, int pageSize);
    IAsyncEnumerable<PersonDto> FindPeopleFromCompanyAsync(Guid companyId);
    IAsyncEnumerable<PersonDto> FindPeopleFromOrganizationAsync(Guid organizationId);

    Task<PersonDto?> FindByIdAsync(Guid id);

    Task<PersonDto> CreateAsync(CreatePersonDto dto);

    Task UpdateAsync(Guid id, UpdatePersonDto dto);

    Task RemoveAsync(Guid id);

    Task AddNoteAsync(Guid personId, string noteText);

    Task AddTagAsync(Guid personId, string tag);
}
