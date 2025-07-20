using MotoGP.Application.Interfaces;
using MotoGP.Application.Interfaces.Services;
using MotoGP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Infrastructure.Services;

public class NewsService : INewsService
{
    private readonly IUnitOfWork _unitOfWork;

    public NewsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<News>> GetAllAsync()
        => await _unitOfWork.News.GetAllAsync();

    public async Task<News?> GetByIdAsync(Guid id)
        => await _unitOfWork.News.GetByIdAsync(id);

    public async Task<News> CreateAsync(News news)
    {
        news.PublishedAt = DateTime.UtcNow;

        await _unitOfWork.News.AddAsync(news);
        await _unitOfWork.SaveChangesAsync();

        return news;
    }

    public async Task<News?> UpdateAsync(Guid id, News updated)
    {
        var news = await _unitOfWork.News.GetByIdAsync(id);
        if (news == null) return null;

        news.Title = updated.Title;
        news.Content = updated.Content;
        news.Category = updated.Category;
        news.ImageUrl = updated.ImageUrl;

        _unitOfWork.News.Update(news);
        await _unitOfWork.SaveChangesAsync();
        return news;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var news = await _unitOfWork.News.GetByIdAsync(id);
        if (news == null) return false;

        _unitOfWork.News.Remove(news);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}

