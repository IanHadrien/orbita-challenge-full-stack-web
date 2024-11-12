using System.ComponentModel.DataAnnotations;

namespace orbita_challenge.Communication.Requests;
public class RequestRegisterUserJson
{
    [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "A Senha deve ter entre 3 e 10 caracteres.")]
    public string Password { get; set; } = string.Empty;
}
