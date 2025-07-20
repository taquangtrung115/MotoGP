using Microsoft.AspNetCore.Mvc;
using MotoGP.Shared.Responses;

namespace MotoGP.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected IActionResult FromResult(Result result)
    {
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }

    protected IActionResult FromResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }
}
