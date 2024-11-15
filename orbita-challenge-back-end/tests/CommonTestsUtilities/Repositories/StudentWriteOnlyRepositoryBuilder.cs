using Moq;
using orbita_challenge.Domain.Repositories.Students;

namespace CommonTestsUtilities.Repositories;
public class StudentWriteOnlyRepositoryBuilder
{
    public static IStudentsWriteOnlyRepository Build()
    {
        var mock = new Mock<IStudentsWriteOnlyRepository>();

        return mock.Object;
    }
}
