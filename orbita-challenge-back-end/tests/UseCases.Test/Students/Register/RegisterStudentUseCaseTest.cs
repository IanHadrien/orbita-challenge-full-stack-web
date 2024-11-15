using CommonTestsUtilities.Cryptography;
using CommonTestsUtilities.Entities;
using CommonTestsUtilities.Mapper;
using CommonTestsUtilities.Repositories;
using CommonTestsUtilities.Request;
using CommonTestsUtilities.Token;
using FluentAssertions;
using orbita_challenge.Application.UseCases.Students.Register;
using orbita_challenge.Application.UseCases.Users;

namespace UseCases.Test.Students.Register;
public class RegisterStudentUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var user = UserBuilder.Build();
        var request = RequestRegisterStudentJsonBuilder.Build();
        var useCase = CreateUseCase(user);

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Nome.Should().BeNull();
    }

    private RegisterStudentUseCase CreateUseCase(orbita_challenge.Domain.Entities.User user)
    {
        var repository = StudentWriteOnlyRepositoryBuilder.Build();
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        //var loggedUser = LoggedUserBuilder.Build(user);

        return new RegisterStudentUseCase(repository, unitOfWork, mapper);
    }
}
