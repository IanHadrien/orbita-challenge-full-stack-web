
using orbita_challenge.Domain.Repositories;
using orbita_challenge.Domain.Repositories.Students;

namespace orbita_challenge.Application.UseCases.Students.Delete;
public class DeleteStudentUseCase : IDeleteStudentUseCase
{
    private readonly IStudentsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStudentUseCase(IStudentsWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new System.Exception("Aulo não deletado");
        }

        await _unitOfWork.Commit();
    }
}
