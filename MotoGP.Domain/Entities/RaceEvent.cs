using MotoGP.Shared.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Domain.Entities;

public class RaceEvent : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public DateTime Date { get; set; }
    public string Location { get; set; } = default!;

    public ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
}


