using Moq;
using orbita_challenge.Domain.Entities;
using orbita_challenge.Domain.Services;

namespace CommonTestsUtilities.Repositories;
public class LoggedUserBuilder
{
    public static ILoggedUser Build(User user)
    {
        var mock = new Mock<ILoggedUser>();

        mock.Setup(loggedUser => loggedUser.Get()).ReturnsAsync(user);

        return mock.Object;
    }
}
