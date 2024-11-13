using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;
using orbita_challenge.Domain.Repositories.Users;
using orbita_challenge.Domain.Security.Cryptography;
using orbita_challenge.Domain.Security.Tokens;

namespace orbita_challenge.Application.UseCases.Login;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(
        IUserReadOnlyRepository repository,
        IPasswordEncripter passwordEncripter,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _passwordEncripter = passwordEncripter;
        _repository = repository;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);

        if (user is null)
        {
            throw new System.Exception("User does not exist");
        }

        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

        if (passwordMatch == false)
        {
            throw new System.Exception("Invalid Password or Email");
        }

        return new ResponseRegisteredUserJson
        {
            Email = user.Email,
            Token = _accessTokenGenerator.Generate(user)
        };
    }
}
