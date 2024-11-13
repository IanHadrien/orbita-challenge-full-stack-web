using orbita_challenge.Domain.Entities;

namespace orbita_challenge.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    string Generate(User user);
}
