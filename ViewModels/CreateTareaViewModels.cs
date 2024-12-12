using System.ComponentModel.DataAnnotations;

public class CreateTareaViewModels
{
    public CreateTareaViewModels()
    {
    }

    [Required][MaxLength(50)]
    public string Titulo {get; set;}

    [Required][MaxLength(150)]
    public string Descripcion {get; set;}

    [Required]
    public Estado Estado {get; set;}

}