using Microsoft.Data.Sqlite;

public class TareaRepository : ITareaRepository
{
    private string _cadenaDeConexion;
    public TareaRepository(string cadenaDeConexion)
    {
        _cadenaDeConexion = cadenaDeConexion;
    }
    public bool CreateTarea(Tarea tarea)
    {
        string query = "INSERT INTO tarea (titulo, descripcion, estado)" +
        "VALUES(@titulo, @descripcion, @estado)";

        int cantidad_filas = 0;

        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);
            command.Parameters.Add(new SqliteParameter("@titulo", tarea.GetTitulo()));
            command.Parameters.Add(new SqliteParameter("@descripcion", tarea.GetDescripcion()));
            command.Parameters.Add(new SqliteParameter("@estado", tarea.GetEstado()));
            cantidad_filas = command.ExecuteNonQuery();
            conexion.Close();
        }
        return cantidad_filas > 0;
    }

    public Tarea GetTarea(int id)
    {
        string query = "SELECT * FROM tarea WHERE id=@idTarea";
        Tarea tarea = null;
        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);
            command.Parameters.Add(new SqliteParameter("@idTarea", id));

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    tarea = new Tarea
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Titulo = reader["titulo"].ToString(),
                        Descripcion = reader["descripcion"].ToString(),
                        Estado = (Estado)Convert.ToInt32(reader["estado"])
                    };
                }
            }
            conexion.Close();
        }
        return tarea;
    }


}
