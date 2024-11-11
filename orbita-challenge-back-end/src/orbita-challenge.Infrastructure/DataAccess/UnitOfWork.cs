using orbita_challenge.Domain.Repositories;

namespace orbita_challenge.Infrastructure.DataAccess;
internal class UnitOfWork : IUnitOfWork
{
    private readonly OrbitaChallengeDbContext _dbContext;

    public UnitOfWork(OrbitaChallengeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
