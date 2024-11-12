namespace orbita_challenge.Domain.Repositories.Users;
public interface IUserWriteOnlyRepository
{
    Task Add(Entities.User user);
}
