using AppCore.ValueObjects;

namespace AppCore.Dto;

public record PersonDto : ContactBaseDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string? Position { get; init; }
    public DateTime? BirthDate { get; init; }
    public Gender Gender { get; init; }
    public Guid? EmployerId { get; init; }

    public static PersonDto FromEntity(AppCore.Models.Person p) => new()
    {
        Id = p.Id,
        FirstName = p.FirstName,
        LastName = p.LastName,
        Position = p.Position,
        BirthDate = p.BirthDate == default ? null : p.BirthDate,
        Gender = p.Gender,
        EmployerId = Guid.TryParse(p.Employer, out var gid) ? gid : (Guid?)null,
        Email = p.Email,
        Phone = p.Phone,
        Address = p.Address is not null ? new AddressDto(p.Address.Street, p.Address.City, p.Address.PostalCode, p.Address.Country, p.Address.AddressType) : null!,
        Status = p.ContactStatus,
        CreatedAt = p.DateTimeCreatedAt,
        Tags = p.Tags?.Select(t => t.Name).ToList() ?? new List<string>()
    };
}

