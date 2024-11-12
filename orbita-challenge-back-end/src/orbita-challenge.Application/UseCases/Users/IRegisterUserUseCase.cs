using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;

namespace orbita_challenge.Application.UseCases.Users;
public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
