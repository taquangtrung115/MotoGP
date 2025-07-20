using MotoGP.Shared.BaseEntity;

namespace MotoGP.Domain.Entities;

public class News : Entity<Guid>
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateTime PublishedAt { get; set; }
    public string Category { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
}
