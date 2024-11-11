using AutoMapper;
using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;
using orbita_challenge.Domain.Entities;
using orbita_challenge.Domain.Repositories;
using orbita_challenge.Domain.Repositories.Students;

namespace orbita_challenge.Application.UseCases.Students.Register;
public class RegisterStudentUseCase : IRegisterStudentUseCase
{
    private readonly IStudentsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterStudentUseCase(
        IStudentsWriteOnlyRepository repository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredStudentJson> Execute(RequestRegisterStundetJson request)
    {

        var entity = _mapper.Map<Student>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredStudentJson>(entity);
    }
}
