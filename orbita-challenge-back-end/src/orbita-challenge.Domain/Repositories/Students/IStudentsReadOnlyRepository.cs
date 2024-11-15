using orbita_challenge.Domain.Entities;

namespace orbita_challenge.Domain.Repositories.Students;
public interface IStudentsReadOnlyRepository
{
    Task<List<Student>> GetAll(string? search);
    Task<Student?> GetById(long id);
}
