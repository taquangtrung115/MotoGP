using MotoGP.Application.Interfaces.Services;
using MotoGP.Application.Interfaces;
using MotoGP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Infrastructure.Services;

public class VideoService : IVideoService
{
    private readonly IUnitOfWork _unitOfWork;

    public VideoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Video>> GetAllAsync() =>
        await _unitOfWork.Videos.GetAllAsync();

    public async Task<Video?> GetByIdAsync(Guid id) =>
        await _unitOfWork.Videos.GetByIdAsync(id);

    public async Task<Video> CreateAsync(Video video)
    {
        video.PublishedAt = DateTime.UtcNow;
        await _unitOfWork.Videos.AddAsync(video);
        await _unitOfWork.SaveChangesAsync();
        return video;
    }

    public async Task<Video?> UpdateAsync(Guid id, Video updated)
    {
        var video = await _unitOfWork.Videos.GetByIdAsync(id);
        if (video == null) return null;

        video.Title = updated.Title;
        video.Url = updated.Url;
        video.Thumbnail = updated.Thumbnail;

        _unitOfWork.Videos.Update(video);
        await _unitOfWork.SaveChangesAsync();
        return video;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var video = await _unitOfWork.Videos.GetByIdAsync(id);
        if (video == null) return false;

        _unitOfWork.Videos.Remove(video);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}

