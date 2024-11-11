using System.ComponentModel.DataAnnotations;

namespace orbita_challenge.Communication.Requests;

public class RequestRegisterStundetJson
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve ter entre 3 e 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo RA é obrigatório.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "O RA deve ter entre 3 e 20 caracteres.")]
    public string RA { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo CPF é obrigatório.")]
    [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF deve ter entre 11 e 14 caracteres.")]
    public string CPF { get; set; } = string.Empty;
}
