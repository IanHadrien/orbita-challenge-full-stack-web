using Microsoft.AspNetCore.Mvc;
using orbita_challenge.Application.UseCases.Users;
using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;

namespace orbita_challenge.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
