using Bogus;
using orbita_challenge.Communication.Requests;

namespace CommonTestsUtilities.Request;
public class RequestRegisterStudentJsonBuilder
{
    public static RequestRegisterStundetJson Build()
    {
        return new Faker<RequestRegisterStundetJson>()
            .RuleFor(r => r.Name, faker => faker.Name.FullName())
            .RuleFor(r => r.CPF, faker => faker.Random.Replace("###.###.###-##"))
            .RuleFor(r => r.Email, faker => faker.Internet.Email())
            .RuleFor(r => r.RA, faker => faker.Random.Replace("RA######"));
    }
}
