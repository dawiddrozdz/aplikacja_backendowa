using System;

namespace AppCore.Models;

public class Customer : EntityBase
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string Email { get; set; }
    
    public required string Phone { get; set; }
    
    // Address może być opcjonalny, więc Guid? jest odpowiednim typem
    public Guid? AddressId { get; set; }
}