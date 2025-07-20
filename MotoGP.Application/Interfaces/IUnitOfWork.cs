using MotoGP.Application.Interfaces.Reponsitory;
using MotoGP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<News> News { get; }
    IGenericRepository<Video> Videos { get; }
    IGenericRepository<RaceEvent> RaceEvents { get; }

    Task<int> SaveChangesAsync();
}

