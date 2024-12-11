

public class Tarea
{
    private int id;
    private string titulo;
    private string descripcion;
    private Estado estado;

    private DateTime fechaCreacion;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Tarea()
    {
    }

    public string GetTitulo()
    {
        return titulo;
    }

    public string GetDescripcion()
    {
        return descripcion;
    }

    public int GetEstado()
    {
        return (int)estado;
    }


}