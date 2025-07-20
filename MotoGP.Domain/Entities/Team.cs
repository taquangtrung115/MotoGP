using MotoGP.Shared.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Domain.Entities;

public class Team : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public string Country { get; set; } = default!;

    public ICollection<Rider> Riders { get; set; } = new List<Rider>();
}

