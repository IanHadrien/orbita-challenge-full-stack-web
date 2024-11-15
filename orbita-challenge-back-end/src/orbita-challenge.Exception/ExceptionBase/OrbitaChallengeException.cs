namespace orbita_challenge.Exception.ExceptionBase;
public abstract class OrbitaChallengeException : SystemException
{
    protected OrbitaChallengeException(string message) : base(message)
    {

    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
