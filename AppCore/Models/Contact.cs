using AppCore.ValueObjects;

namespace AppCore.Models;

public abstract class Contact : EntityBase
{
    public required string Email { get; set; }
    
    public required string Phone { get; set; }
    
    public required Address? Address { get; set; }
    
    public required DateTime DateTimeCreatedAt { get; set; }
    
    public DateTime? DateTimeUpdatedAt { get; set; }
    
    public required ContactStatus ContactStatus { get; set; }
    
    public List<Tag> Tags { get; set; } = [];
    
    public List<Note> Notes { get; set; } = [];
    
    public abstract string GetDisplayName();
}

