using System.ComponentModel.DataAnnotations;

namespace orbita_challenge.Communication.Requests;
public class RequestUpdateStudentJson
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve ter entre 3 e 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
    public string Email { get; set; } = string.Empty;
}
