using MotoGP.Application.Interfaces;
using MotoGP.Application.Interfaces.Services;
using MotoGP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Infrastructure.Services;

public class RaceEventService : IRaceEventService
{
    private readonly IUnitOfWork _unitOfWork;

    public RaceEventService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RaceEvent>> GetAllAsync() =>
        await _unitOfWork.RaceEvents.GetAllAsync();

    public async Task<RaceEvent?> GetByIdAsync(Guid id) =>
        await _unitOfWork.RaceEvents.GetByIdAsync(id);

    public async Task<RaceEvent> CreateAsync(RaceEvent RaceEvent)
    {
        RaceEvent.Date = DateTime.UtcNow;
        await _unitOfWork.RaceEvents.AddAsync(RaceEvent);
        await _unitOfWork.SaveChangesAsync();
        return RaceEvent;
    }

    public async Task<RaceEvent?> UpdateAsync(Guid id, RaceEvent updated)
    {
        var RaceEvent = await _unitOfWork.RaceEvents.GetByIdAsync(id);
        if (RaceEvent == null) return null;

        RaceEvent.Name = updated.Name;
        RaceEvent.Date = updated.Date;
        RaceEvent.Location = updated.Location;

        _unitOfWork.RaceEvents.Update(RaceEvent);
        await _unitOfWork.SaveChangesAsync();
        return RaceEvent;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var RaceEvent = await _unitOfWork.RaceEvents.GetByIdAsync(id);
        if (RaceEvent == null) return false;

        _unitOfWork.RaceEvents.Remove(RaceEvent);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
