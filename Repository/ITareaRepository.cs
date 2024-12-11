public interface ITareaRepository
{
    public bool CreateTarea(Tarea tarea);
    public Tarea GetTarea(int id);
    
   /* public bool UpdateTarea(int id, Tarea tarea);
    public bool DeleteTarea(int id);
    public List<Tarea> GetTareas();
    public List<Tarea> GetTareasByEstado(Estado estado);*/
}