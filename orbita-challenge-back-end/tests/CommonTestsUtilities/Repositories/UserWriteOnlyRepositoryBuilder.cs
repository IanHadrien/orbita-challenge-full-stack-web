using Moq;
using orbita_challenge.Domain.Repositories.Users;

namespace CommonTestsUtilities.Repositories;
public class UserWriteOnlyRepositoryBuilder
{
    public static IUserWriteOnlyRepository Build()
    {
        var mock = new Mock<IUserWriteOnlyRepository>();
        return mock.Object;
    }
}
