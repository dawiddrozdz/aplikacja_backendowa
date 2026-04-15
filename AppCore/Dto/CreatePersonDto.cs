using AppCore.ValueObjects;
using AppCore.Models;

namespace AppCore.Dto;

public record CreatePersonDto(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string? Position,
    DateTime? BirthDate,
    Gender Gender,
    Guid? EmployerId,
    AddressDto? Address
)
{
    public Person ToEntity(Guid id)
    {
        var person = new Person()
        {
            Id = id,
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = string.Empty,
            BirthDate = BirthDate ?? default,
            Gender = Gender,
            Position = Position,
            Email = Email,
            Phone = Phone,
            Address = Address is not null ? new AppCore.Models.Address
            {
                Id = Guid.NewGuid(),
                Street = Address.Street,
                City = Address.City,
                PostalCode = Address.PostalCode,
                Country = Address.Country,
                AddressType = Address.Type
            } : null!,
            DateTimeCreatedAt = DateTime.UtcNow,
            ContactStatus = ContactStatus.Active
        };

        return person;
    }
};
