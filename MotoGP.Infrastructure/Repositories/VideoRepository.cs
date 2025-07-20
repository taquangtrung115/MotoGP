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

public class VideoRepository : IVideoRepository
{
    private readonly MotoGPDbContext _context;

    public VideoRepository(MotoGPDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Video>> GetAllAsync() =>
        await _context.Videos.OrderByDescending(n => n.PublishedAt).ToListAsync();

    public async Task<Video?> GetByIdAsync(Guid id) =>
        await _context.Videos.FindAsync(id);

    public async Task AddAsync(Video news) =>
        await _context.Videos.AddAsync(news);

    public void Update(Video news) =>
        _context.Videos.Update(news);

    public void Remove(Video news) =>
        _context.Videos.Remove(news);
}
