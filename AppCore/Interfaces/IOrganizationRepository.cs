using AppCore.Models;
using AppCore.ValueObjects;

namespace AppCore.Interfaces;

public interface IOrganizationRepository : IGenericRepositoryAsync<Organization>
{
    Task<IEnumerable<Organization>> GetByTypeAsync(OrganizationType type);
    Task<IEnumerable<Person>> GetMembersAsync(Guid organizationId);
}
