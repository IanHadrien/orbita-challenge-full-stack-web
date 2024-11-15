using orbita_challenge.Communication.Responses;

namespace orbita_challenge.Application.UseCases.Students.GetAll;
public interface IGetAllStudentsUseCase
{
    Task<ResponseStudentsJson> Execute(string? search);
}
