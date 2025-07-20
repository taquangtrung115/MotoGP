using MotoGP.Shared.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Domain.Entities;

public class RaceResult : Entity<Guid>
{
    public Guid RiderId { get; set; }
    public Guid RaceEventId { get; set; }
    public int Position { get; set; }
    public int Points { get; set; }

    public Rider Rider { get; set; } = default!;
    public RaceEvent RaceEvent { get; set; } = default!;
}
