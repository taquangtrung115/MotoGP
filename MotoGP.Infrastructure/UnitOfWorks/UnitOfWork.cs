using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using MotoGP.Application.Interfaces;
using MotoGP.Application.Interfaces.Reponsitory;
using MotoGP.Domain.Entities;
using MotoGP.Infrastructure.Repositories;
using MotoGP.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoGP.Shared.BaseEntity;

namespace MotoGP.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly MotoGPDbContext _context;

    public IGenericRepository<News> News { get; }
    public IGenericRepository<Video> Videos { get; }
    public IGenericRepository<RaceEvent> RaceEvents { get; }

    public UnitOfWork(MotoGPDbContext context)
    {
        _context = context;
        News = new GenericRepository<News>(_context);
        Videos = new GenericRepository<Video>(_context);
        RaceEvents = new GenericRepository<RaceEvent>(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        var entries = _context.ChangeTracker.Entries<IAuditableEntity>();

        var now = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.DateCreate = now;
                    break;

                case EntityState.Modified:
                    entry.Entity.DateUpdate = now;
                    break;

                case EntityState.Deleted:
                    // Soft Delete
                    entry.State = EntityState.Modified;
                    entry.Entity.DateDelete = now;
                    entry.Entity.IsDelete = true;
                    break;
            }
        }

        return await _context.SaveChangesAsync();
    }
    public void Dispose() => _context.Dispose();
}


