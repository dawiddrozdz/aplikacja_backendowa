using AppCore.Interfaces;
using AppCore.Models;
using AppCore.ValueObjects;

namespace Infrastructure.Memory;

public class MemoryOrganizationRepository : MemoryGenericRepository<Organization>, IOrganizationRepository
{
    public MemoryOrganizationRepository() : base()
    {
        var id1 = Guid.Parse("A5F1C8E2-72DB-4B5A-9C1F-8E3A2B5D4F6A");
        _data.Add(id1, new Organization()
        {
            Id = id1,
            Name = "Tech Innovations Inc.",
            Email = "contact@techinnovations.pl",
            Phone = "123-456-789",
            OrganizationType = OrganizationType.PublicInstitution,
            ARS = "123-456-789",
            Website = "https://techinnovations.pl",
            Address = new Address
            {
                Id = Guid.NewGuid(),
                Street = "Technology Boulevard 42",
                City = "Warsaw",
                PostalCode = "02-000",
                Country = Country.Pl.ToString(),
                AddressType = AddressType.Office
            },
            DateTimeCreatedAt = DateTime.UtcNow,
            ContactStatus = ContactStatus.Active
        });
    }

    public Task<IEnumerable<Organization>> GetByTypeAsync(OrganizationType type)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Person>> GetMembersAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public Task GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
