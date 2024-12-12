public class GetTareaViewModels
{
    public GetTareaViewModels(Tarea tarea)
    {
        Titulo = tarea.Titulo;
        Descripcion = tarea.Descripcion;
        Estado = tarea.Estado;
    }

    public string Titulo {get; set;}
    public string Descripcion {get; set;}
    public Estado Estado {get; set;}
}