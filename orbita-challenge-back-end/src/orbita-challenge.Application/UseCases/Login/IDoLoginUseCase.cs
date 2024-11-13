using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;

namespace orbita_challenge.Application.UseCases.Login;
public interface IDoLoginUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}
