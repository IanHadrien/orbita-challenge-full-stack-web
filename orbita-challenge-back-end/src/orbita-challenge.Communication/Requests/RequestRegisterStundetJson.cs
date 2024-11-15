using System.ComponentModel.DataAnnotations;

namespace orbita_challenge.Communication.Requests;

public class RequestRegisterStundetJson
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve ter mais de 3 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo RA é obrigatório.")]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "O RA deve ter 6 caracteres.")]
    public string RA { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo CPF é obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
    public string CPF { get; set; } = string.Empty;
}
