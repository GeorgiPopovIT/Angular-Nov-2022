namespace GorgesMusic.Data.Models;

public class BaseModel
{
    public int Id { get; init; }

    public DateTime CreatedOn { get; init; } = DateTime.UtcNow;
}
