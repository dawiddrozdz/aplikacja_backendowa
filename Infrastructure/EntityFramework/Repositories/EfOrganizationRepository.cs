using AppCore.Interfaces;
using AppCore.Models;
using AppCore.ValueObjects;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories;

public class EfOrganizationRepository(ContactsDbContext context) :
    EfGenericRepository<Organization>(context.Organizations),
    IOrganizationRepository
{
    public async Task<IEnumerable<Organization>> GetByTypeAsync(OrganizationType type)
    {
        return await context.Organizations.Where(o => o.OrganizationType == type).ToListAsync();
    }

    public async Task<IEnumerable<Person>> GetMembersAsync(Guid organizationId)
    {
        return await context.People.Where(p => p.Organization != null && p.Organization.Id == organizationId).ToListAsync();
    }

    public async Task GetAllAsync()
    {
        await context.Organizations.ToListAsync();
    }
}
