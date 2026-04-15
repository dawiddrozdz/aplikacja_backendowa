using AppCore.Interfaces;
using AppCore.Models;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories;

public class EfPersonRepository(ContactsDbContext context) :
    EfGenericRepository<Person>(context.People),
    IPersonRepository
{
    public async Task<IEnumerable<Person>> GetByCompanyAsync(Guid companyId)
    {
        return await context.People.Where(p => p.Employer != null && p.Employer.Id == companyId).ToListAsync();
    }

    public async Task<IEnumerable<Person>> GetByOrganizationAsync(Guid organizationId)
    {
        return await context.People.Where(p => p.Organization != null && p.Organization.Id == organizationId).ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await RemoveByIdAsync(id);
    }
}
