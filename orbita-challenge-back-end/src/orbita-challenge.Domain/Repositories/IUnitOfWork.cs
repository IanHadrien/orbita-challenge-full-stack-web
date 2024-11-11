namespace orbita_challenge.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
