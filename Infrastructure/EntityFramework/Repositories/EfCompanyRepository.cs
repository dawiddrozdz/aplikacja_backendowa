using AppCore.Interfaces;
using AppCore.Models;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories;

public class EfCompanyRepository(ContactsDbContext context) :
    EfGenericRepository<Company>(context.Companies),
    ICompanyRepository
{
    public async Task<Company?> FindByNipAsync(string nip)
    {
        return await context.Companies.FirstOrDefaultAsync(c => c.NIP == nip);
    }

    public async Task<IEnumerable<Company>> FindByNameAsync(string namePart)
    {
        return await context.Companies.Where(c => c.Name.Contains(namePart)).ToListAsync();
    }

    public async Task<IEnumerable<Person>> GetEmployeesAsync(Guid companyId)
    {
        return await context.People.Where(p => p.Employer != null && p.Employer.Id == companyId).ToListAsync();
    }
}
