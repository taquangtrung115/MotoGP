using MotoGP.Shared.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Domain.Entities;

public class Video : Entity<Guid>
{
    public string Title { get; set; } = default!;
    public string Url { get; set; } = default!;
    public string Thumbnail { get; set; } = default!;
    public DateTime PublishedAt { get; set; }
    public string Category { get; set; } = default!;
}
