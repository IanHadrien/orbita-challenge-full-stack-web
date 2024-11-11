using orbita_challenge.Domain.Entities;

namespace orbita_challenge.Domain.Repositories.Students;
public interface IStudentUpdateOnlyRepository
{
    Task<Student?> GetById(long id);
    void Update(Student expense);
}
