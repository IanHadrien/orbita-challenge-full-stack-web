using Microsoft.EntityFrameworkCore;
using orbita_challenge.Domain.Entities;
using orbita_challenge.Domain.Repositories.Students;

namespace orbita_challenge.Infrastructure.DataAccess.Repositories;
internal class StudentsRepository : IStudentsReadOnlyRepository, IStudentsWriteOnlyRepository
{
    private readonly OrbitaChallengeDbContext _dbContext;
    public StudentsRepository(OrbitaChallengeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Student student)
    {
        await _dbContext.Students.AddAsync(student);
    }

    public async Task<List<Student>> GetAll()
    {
        return await _dbContext.Students.AsNoTracking().ToListAsync();
    }

    public async Task<Student?> GetById(long id)
    {
        return await _dbContext.Students.AsNoTracking().FirstOrDefaultAsync(student => student.Id == id);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Students.FirstOrDefaultAsync(stundet => stundet.Id == id);

        if (result is null)
        {
            return false;
        }

        _dbContext.Students.Remove(result);

        return true;
    }
}
