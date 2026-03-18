using AppCore.Interfaces;
using AppCore.Models;
using AppCore.ValueObjects;

namespace Infrastructure.Memory;

public class MemoryPersonRepository : MemoryGenericRepository<Person>, IPersonRepository
{
    public MemoryPersonRepository() : base()
    {
        var id1 = Guid.Parse("732B7F3A-CCEA-43B0-8E47-EEC4A0F0041A");
        _data.Add(id1, new Person()
        {
            Id = id1,
            FirstName = "Adam",
            LastName = "Nowak",
            MiddleName = string.Empty,
            Gender = Gender.Male,
            BirthDate = DateTime.UtcNow.AddYears(-30),
            Email = "adam.nowak@example.com",
            Phone = "111-111-111",
            Address = new Address
            {
                Id = Guid.NewGuid(),
                Street = "Main 1",
                City = "City",
                PostalCode = "00-001",
                Country = Country.Pl.ToString(),
                AddressType = AddressType.Home
            },
            DateTimeCreatedAt = DateTime.UtcNow,
            ContactStatus = ContactStatus.Active
        });

        var id2 = Guid.NewGuid();
        _data.Add(id2, new Person()
        {
            Id = id2,
            FirstName = "Ewa",
            LastName = "Kowalska",
            MiddleName = string.Empty,
            Gender = Gender.Female,
            BirthDate = DateTime.UtcNow.AddYears(-25),
            Email = "ewa.kowalska@example.com",
            Phone = "222-222-222",
            Address = new Address
            {
                Id = Guid.NewGuid(),
                Street = "Second 2",
                City = "City",
                PostalCode = "00-002",
                Country = Country.Pl.ToString(),
                AddressType = AddressType.Work
            },
            DateTimeCreatedAt = DateTime.UtcNow,
            ContactStatus = ContactStatus.Active
        });
    }

    public async Task<IEnumerable<Person>> GetByCompanyAsync(Guid companyId)
    {
        return _data.Values.Where(p => p.Employer != null && Guid.TryParse(p.Employer, out var gid) && gid == companyId);
    }

    public Task<IEnumerable<Person>> GetByOrganizationAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
