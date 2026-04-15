using AppCore.ValueObjects;

namespace AppCore.Models;

public class Organization : Contact
{
    public required string Name { get; set; }
    
    public required OrganizationType OrganizationType { get; set; }
    
    public string? ARS { get; set; }
    
    public string? Website { get; set; }
    
    public List<Person> Members { get; set; } = [];
    
    public Person? PrimaryContact { get; set; }

    public override string GetDisplayName()
    {
        return Name;
    }
}
