using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Shared.BaseEntity;

public abstract class Entity<TId> : IAuditableEntity
{
    public TId Id { get; protected set; } = default!;
    public DateTime? DateUpdate { get ; set ; } 
    public DateTime? DateCreate { get ; set ; }
    public DateTime? DateDelete { get ; set ; } 
    public Guid? UserCreate { get ; set ; }
    public Guid? UserUpdate { get ; set ; }
    public Guid? UserDelete { get ; set ; }
    public bool IsDelete { get ; set ; } = false;

    public override bool Equals(object obj)
    {
        if (obj is not Entity<TId> entity) return false;
        return EqualityComparer<TId>.Default.Equals(Id, entity.Id);
    }

    public override int GetHashCode() => HashCode.Combine(Id);
}
