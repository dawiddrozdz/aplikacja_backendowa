namespace AppCore.Dto;

public record NoteDto(
    Guid Id,
    string Content,
    DateTime DateTimeCreatedAt
)
{
    public static NoteDto FromEntity(AppCore.Models.Note note) => new(
        note.Id,
        note.Content,
        note.DateTimeCreatedAt
    );
};

