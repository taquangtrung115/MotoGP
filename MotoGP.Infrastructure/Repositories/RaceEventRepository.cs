using Microsoft.EntityFrameworkCore;
using MotoGP.Application.Interfaces.Reponsitory;
using MotoGP.Domain.Entities;
using MotoGP.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Infrastructure.Repositories;

public class RaceEventRepository : IRaceEventRepository
{
    private readonly MotoGPDbContext _context;

    public RaceEventRepository(MotoGPDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RaceEvent>> GetAllAsync() =>
        await _context.RaceEvents.OrderByDescending(n => n.Date).ToListAsync();

    public async Task<RaceEvent?> GetByIdAsync(Guid id) =>
        await _context.RaceEvents.FindAsync(id);

    public async Task AddAsync(RaceEvent news) =>
        await _context.RaceEvents.AddAsync(news);

    public void Update(RaceEvent news) =>
        _context.RaceEvents.Update(news);

    public void Remove(RaceEvent news) =>
        _context.RaceEvents.Remove(news);
}
