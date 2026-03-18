using AppCore.ValueObjects;

namespace AppCore.Models;

public class Organization : EntityBase
{
    public required string Name { get; set; }
    
    public required OrganizationType OrganizationType { get; set; }
    
    public string? ARS { get; set; }
    
    public string? Website { get; set; }
    
    public Address? Address { get; set; }
    
    public List<Person> CategoryMembers { get; set; } = [];
    
    public Person? PrimaryContact { get; set; }
    public DateTime DateTimeCreatedAt { get; set; }
    public ContactStatus ContactStatus { get; set; }
}

