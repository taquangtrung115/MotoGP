using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Shared.BaseEntity;

public interface IAuditableEntity
{
    public DateTime? DateUpdate { get;  set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateDelete { get; set; }
    public Guid? UserCreate { get; set; }
    public Guid? UserUpdate { get;  set; }
    public Guid? UserDelete { get; set; }
    public bool IsDelete { get; set; }
}
