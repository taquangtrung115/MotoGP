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

public class NewsRepository : INewsRepository
{
    private readonly MotoGPDbContext _context;

    public NewsRepository(MotoGPDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<News>> GetAllAsync() =>
        await _context.News.OrderByDescending(n => n.PublishedAt).ToListAsync();

    public async Task<News?> GetByIdAsync(Guid id) =>
        await _context.News.FindAsync(id);

    public async Task AddAsync(News news) =>
        await _context.News.AddAsync(news);

    public void Update(News news) =>
        _context.News.Update(news);

    public void Remove(News news) =>
        _context.News.Remove(news);
}

