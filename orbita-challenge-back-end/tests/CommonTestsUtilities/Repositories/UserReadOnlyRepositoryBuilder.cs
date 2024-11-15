using Moq;
using orbita_challenge.Domain.Entities;
using orbita_challenge.Domain.Repositories.Users;

namespace CommonTestsUtilities.Repositories;
public class UserReadOnlyRepositoryBuilder
{
    private readonly Mock<IUserReadOnlyRepository> _repository;
    public UserReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<IUserReadOnlyRepository>();
    }

    public UserReadOnlyRepositoryBuilder GetUserByEmail(User user)
    {
        _repository.Setup(userRepository => userRepository.GetUserByEmail(user.Email)).ReturnsAsync(user);

        return this;
    }

    public IUserReadOnlyRepository Build() => _repository.Object;
}
