using orbita_challenge.Domain.Entities;

namespace orbita_challenge.Domain.Services;
public interface ILoggedUser
{
    Task<User> Get();
}
