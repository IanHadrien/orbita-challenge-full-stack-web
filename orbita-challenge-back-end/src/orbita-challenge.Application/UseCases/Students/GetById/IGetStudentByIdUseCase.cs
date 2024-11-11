using orbita_challenge.Communication.Responses;

namespace orbita_challenge.Application.UseCases.Students.GetById;
public interface IGetStudentByIdUseCase
{
    Task<ResponseOneStudentJson> Execute(long id);
}
