﻿namespace orbita_challenge.Domain.Entities;
public class User
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
