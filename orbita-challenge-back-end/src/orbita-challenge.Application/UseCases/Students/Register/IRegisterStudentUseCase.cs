using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;

namespace orbita_challenge.Application.UseCases.Students.Register;
public interface IRegisterStudentUseCase
{
    Task<ResponseRegisteredStudentJson> Execute(RequestRegisterStundetJson request);
}
