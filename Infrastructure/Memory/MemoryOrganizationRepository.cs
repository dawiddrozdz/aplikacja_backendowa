using AppCore.Interfaces;
using AppCore.Models;
using AppCore.ValueObjects;

namespace Infrastructure.Memory;

public class MemoryOrganizationRepository : MemoryGenericRepository<Organization>, IOrganizationRepository
{
    public MemoryOrganizationRepository() : base()
    {
        // no sample data for now
    }

    public Task<IEnumerable<Organization>> GetByTypeAsync(OrganizationType type)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Person>> GetMembersAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }
}
