using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoGP.Application.Interfaces.Services;
using MotoGP.Domain.Entities;

namespace MotoGP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VideosController : BaseController
{
    private readonly IVideoService _videoService;

    public VideosController(IVideoService videoService)
    {
        _videoService = videoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _videoService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _videoService.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Video video) =>
        Ok(await _videoService.CreateAsync(video));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Video video)
    {
        var updated = await _videoService.UpdateAsync(id, video);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) =>
        Ok(await _videoService.DeleteAsync(id));
}

