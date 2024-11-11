using Microsoft.AspNetCore.Mvc;
using orbita_challenge.Application.UseCases.Students.GetAll;
using orbita_challenge.Application.UseCases.Students.GetById;
using orbita_challenge.Application.UseCases.Students.Register;
using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;

namespace orbita_challenge_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredStudentJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterStudentUseCase useCase,
        [FromBody] RequestRegisterStundetJson request
     )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseStudentsJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllStudents([FromServices] IGetAllStudentsUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Students.Count != 0)
            return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseOneStudentJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetStudentByIdUseCase useCase,
        [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }
}
