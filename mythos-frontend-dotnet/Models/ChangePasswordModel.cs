using System.ComponentModel.DataAnnotations;

namespace mythos_frontend_dotnet.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "La nueva contraseña es requerida")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string NewPassword { get; set; } = string.Empty;
    }
}
