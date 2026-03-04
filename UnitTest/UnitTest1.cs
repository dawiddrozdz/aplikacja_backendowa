using AppCore.Interfaces;
using AppCore.Models;
using Infrastructure.Memory;

namespace UnitTest;

public class MemoryGenericRepositoryTest
{
    private IGenericRepositoryAsync<Person> _repo = new MemoryGenericRepository<Person>();

    [Fact]
    public async Task AddPersonTestAsync()
    {
        // Arrange
        var personId = Guid.NewGuid();
        var addressId = Guid.NewGuid();
        var expected = new Person
        {
            Id = personId,
            FirstName = "Adam",
            LastName = "Test",
            Email = "adam@test.com",
            Phone = "123456789",
            MiddleName = "Middle",
            BirthDate = new DateTime(1990, 1, 1),
            Gender = AppCore.ValueObjects.Gender.Male,
            Address = new Address
            {
                Id = addressId,
                Street = "Test Street",
                City = "Test City",
                PostalCode = "00-000",
                Country = AppCore.ValueObjects.Country.Pl,
                AddressType = AppCore.ValueObjects.AddressType.Main
            },
            ContactStatus = AppCore.ValueObjects.ContactStatus.Active,
            DateTimeCreatedAt = DateTime.UtcNow,
            Tags = new List<Tag>(),
            Notes = new List<Note>()
        };

        // Act
        await _repo.AddAsync(expected);
        var actual = await _repo.FindByIdAsync(expected.Id);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(personId, actual.Id);
        Assert.Equal("Adam", actual.FirstName);
    }
}