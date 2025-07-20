namespace MotoGP.API.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoGP.Application.Interfaces.Services;
using MotoGP.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NewsController : BaseController
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _newsService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _newsService.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] News news)
        => Ok(await _newsService.CreateAsync(news));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] News news)
    {
        var updated = await _newsService.UpdateAsync(id, news);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
        => Ok(await _newsService.DeleteAsync(id));
}

