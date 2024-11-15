using Bogus;
using orbita_challenge.Communication.Requests;

namespace CommonTestsUtilities.Request;
public class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build()
    {
        return new Faker<RequestRegisterUserJson>()
            .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Email))
            .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix: "!Aa1"));
    }
}
