using AutoMapper;
using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;
using orbita_challenge.Domain.Repositories;
using orbita_challenge.Domain.Repositories.Users;
using orbita_challenge.Domain.Security.Cryptography;
using orbita_challenge.Domain.Security.Tokens;

namespace orbita_challenge.Application.UseCases.Users;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccessTokenGenerator _tokenGenerator;

    public RegisterUserUseCase(
        IMapper mapper, 
        IPasswordEncripter passwordEncripter,
        IUserReadOnlyRepository userReadOnlyRepository,
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IUnitOfWork unitOfWork,
        IAccessTokenGenerator tokenGenerator)
    {
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _userReadOnlyRepository = userReadOnlyRepository;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _tokenGenerator = tokenGenerator;
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

        await _userWriteOnlyRepository.Add(user);

        await _unitOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Email = user.Email,
            Token = _tokenGenerator.Generate(user)
        };
    }
}
