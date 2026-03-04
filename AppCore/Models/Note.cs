namespace AppCore.Models;

public class Note : EntityBase
{
    public required string Content { get; set; }
    
    public required DateTime DateTimeCreatedAt { get; set; }
}

