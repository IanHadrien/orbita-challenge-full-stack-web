namespace orbita_challenge.Domain.Security.Cryptography;
public interface IPasswordEncripter
{
    string Encrypt(string password);
}
