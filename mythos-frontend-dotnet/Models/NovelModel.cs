using System;
using System.ComponentModel.DataAnnotations;

namespace mythos_frontend_dotnet.Models;

public class NovelModel
{
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "El título es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El título debe tener entre 3 y 100 caracteres")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es obligatoria")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 1000 caracteres")]
    public string Description { get; set; } = string.Empty;

    [MinLength(1, ErrorMessage = "Debes seleccionar al menos un género")]
    public List<string> Genres { get; set; } = [];

    [MinLength(1, ErrorMessage = "Debes seleccionar al menos un Tag")]
    [MaxLength(10, ErrorMessage = "Máximo 10 etiquetas")]
    public List<string> Tags { get; set; } = [];

    public string CoverImageUrl { get; set; } = string.Empty;

    public string WriterAccountId { get; set; } = string.Empty;

    public string WriterName { get; set; } = string.Empty;

    public DateTime UpdatedAt { get; set; }
}
