using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;

namespace orbita_challenge.Application.UseCases.Students.Register;
public class RegisterStudentUseCase
{
    public ResponseRegisteredStudentJson Execute(RequestRegisterStundetJson request)
    {
        return new ResponseRegisteredStudentJson();
    }
}
