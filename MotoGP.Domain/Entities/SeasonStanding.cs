using MotoGP.Shared.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Domain.Entities;

public class SeasonStanding : Entity<Guid>
{
    public int SeasonYear { get; set; }
    public Guid RiderId { get; set; }
    public int TotalPoints { get; set; }
    public int Position { get; set; }

    public Rider Rider { get; set; } = default!;
}
