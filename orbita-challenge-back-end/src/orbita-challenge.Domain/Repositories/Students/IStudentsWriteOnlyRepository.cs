using orbita_challenge.Domain.Entities;

namespace orbita_challenge.Domain.Repositories.Students;
public interface IStudentsWriteOnlyRepository
{
    Task Add(Student student);
    Task<bool> Delete(long id);
}
