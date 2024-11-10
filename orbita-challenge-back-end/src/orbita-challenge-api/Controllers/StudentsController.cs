using Microsoft.AspNetCore.Mvc;
using orbita_challenge.Application.UseCases.Students.Register;
using orbita_challenge.Communication.Requests;

namespace orbita_challenge_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterStundetJson request)
    {
        try
        {
            var useCase = new RegisterStudentUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        } 
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
