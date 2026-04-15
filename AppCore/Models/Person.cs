using AppCore.ValueObjects;

namespace AppCore.Models;

public class Person : Contact
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string MiddleName { get; set; }
    
    public required DateTime BirthDate { get; set; }
    
    public required Gender Gender { get; set; }
    
    public string? Position { get; set; }
    
    public Organization? Organization { get; set; }
    
    public Company? Employer { get; set; }

    public override string GetDisplayName()
    {
        return $"{FirstName} {LastName}";
    }
}
