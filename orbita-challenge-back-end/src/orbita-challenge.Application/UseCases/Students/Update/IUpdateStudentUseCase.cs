using orbita_challenge.Communication.Requests;

namespace orbita_challenge.Application.UseCases.Students.Update;

public interface IUpdateStudentUseCase
{
    Task Execute(long id, RequestUpdateStudentJson request);
}
