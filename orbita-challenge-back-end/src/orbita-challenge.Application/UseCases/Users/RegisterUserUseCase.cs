using AutoMapper;
using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;
using orbita_challenge.Domain.Repositories.Users;
using orbita_challenge.Domain.Security.Cryptography;

namespace orbita_challenge.Application.UseCases.Users;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;

    public RegisterUserUseCase(
        IMapper mapper, 
        IPasswordEncripter passwordEncripter,
        IUserReadOnlyRepository userReadOnlyRepository)
    {
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        var user = _mapper.Map<Domain.Entities.User>(request);

        var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
        if (emailExist)
        {
            throw new System.Exception("Email already registered");
        }

        user.Password = _passwordEncripter.Encrypt(request.Password);

        return new ResponseRegisteredUserJson
        {
            Email = user.Email,
        };
    }
}
