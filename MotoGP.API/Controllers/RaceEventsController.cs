using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoGP.Application.Interfaces.Services;
using MotoGP.Domain.Entities;

namespace MotoGP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RaceEventsController : BaseController
{
    private readonly IRaceEventService _raceEventService;

    public RaceEventsController(IRaceEventService newsService)
    {
        _raceEventService = newsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _raceEventService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _raceEventService.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RaceEvent news)
        => Ok(await _raceEventService.CreateAsync(news));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] RaceEvent news)
    {
        var updated = await _raceEventService.UpdateAsync(id, news);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
        => Ok(await _raceEventService.DeleteAsync(id));
}
