using AutoMapper;
using orbita_challenge.Communication.Requests;
using orbita_challenge.Domain.Repositories;
using orbita_challenge.Domain.Repositories.Students;

namespace orbita_challenge.Application.UseCases.Students.Update;
public class UpdateStudentUseCase : IUpdateStudentUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentUpdateOnlyRepository _repository;

    public UpdateStudentUseCase(IMapper mapper, IUnitOfWork unitOfWork, IStudentUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long id, RequestUpdateStudentJson request)
    {
        var student = await _repository.GetById(id);

        if (student is null)
        {
            throw new NotImplementedException(); // melhorar erro
        }

        _mapper.Map(request, student);

        _repository.Update(student);

        await _unitOfWork.Commit();
    }
}
