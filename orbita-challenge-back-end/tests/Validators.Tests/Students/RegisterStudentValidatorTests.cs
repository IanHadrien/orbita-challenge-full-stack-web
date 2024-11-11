using orbita_challenge.Application.UseCases.Students.Register;
using orbita_challenge.Communication.Requests;

namespace Validators.Tests.Students;
public class RegisterStudentValidatorTests
{
    [Fact]
    public void Sucess()
    {
        // Arrange
        var request = new RequestRegisterStundetJson
        {
            Nome = "ian",
            Email = "test",
            RA = "123",
            CPF = "12312312312",
        };

        // Act
        var useCase = new RegisterStudentUseCase();
        var result = useCase.Execute(request);

        // Assert
        Assert.NotNull(result);
        //Assert.True(result.Success);
        Assert.Equal("ian", result.Nome);
    }
}
