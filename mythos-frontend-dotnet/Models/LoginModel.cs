using System.ComponentModel.DataAnnotations;

namespace mythos_frontend_dotnet.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        //[EmailAddress(ErrorMessage = "Formato de correo electrónico inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres", MinimumLength = 6)]
        public string? Password { get; set; }
    }
}
