using System.ComponentModel.DataAnnotations;

namespace mythos_frontend_dotnet.Models;

public class CreateChapterModel
{
    [Required(ErrorMessage = "El título del capítulo es requerido")]
    [StringLength(100, ErrorMessage = "El título no puede exceder 100 caracteres")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "El contenido del capítulo es requerido")]
    public string Content { get; set; } = string.Empty;

    public string NovelId { get; set; } = string.Empty;

    public int PriceMythras { get; set; } = 0;
}
