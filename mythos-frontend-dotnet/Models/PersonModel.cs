using System.ComponentModel.DataAnnotations;

namespace mythos_frontend_dotnet.Models;

public class PersonModel
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(PersonModel), nameof(ValidateBirthDate))]
    public DateTime? BirthDate { get; set; }

    [Required(ErrorMessage = "El país es obligatorio.")]
    [StringLength(56, ErrorMessage = "El país debe tener máximo 56 caracteres.")]
    public string Country { get; set; } = string.Empty;

    [Required(ErrorMessage = "La biografía es obligatoria.")]
    [StringLength(1000, MinimumLength = 50, ErrorMessage = "La biografía debe tener entre 50 y 1000 caracteres.")]
    public string Biography { get; set; } = string.Empty;

    public static ValidationResult? ValidateBirthDate(DateTime birthDate, ValidationContext context)
    {
        var today = DateTime.Today;
        var minDate = today.AddYears(-16);
        var maxDate = today.AddYears(-120);

        if (birthDate > today)
            return new ValidationResult("La fecha de nacimiento no puede ser en el futuro.");

        if (birthDate > minDate)
            return new ValidationResult("Debes tener al menos 16 años para registrarte");

        if (birthDate < maxDate)
            return new ValidationResult("La fecha de nacimiento no puede tener más de 120 años");

        return ValidationResult.Success;
    }
}
