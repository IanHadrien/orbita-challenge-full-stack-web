using Bogus;
using CommonTestsUtilities.Cryptography;
using orbita_challenge.Domain.Entities;

namespace CommonTestsUtilities.Entities;
public class UserBuilder
{
    public static User Build()
    {
        var passwordEncripter = new PasswordEncrypterBuilder().Build();

        var user = new Faker<User>()
            .RuleFor(u => u.Id, _ => 1)
            .RuleFor(u => u.Email, faker => faker.Internet.Email())
            .RuleFor(u => u.Password, (_, user) => passwordEncripter.Encrypt(user.Password));

        return user;
    }
}
