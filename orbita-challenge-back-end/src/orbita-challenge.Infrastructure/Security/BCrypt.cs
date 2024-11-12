﻿using orbita_challenge.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace orbita_challenge.Infrastructure.Security;
internal class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }
}
