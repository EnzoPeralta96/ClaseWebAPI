# ClaseWebAPI

Implementación de una API REST FULL con C# y el framework de .NET

Pasos para implementar la API:

1 - Crear el template de la web api con ASP
    (versión 7): dotnet new webapi
    (versión 8+): dotnet new webapi --use-controller

2 - Crear los modelos necesarios, esta caso el modelo Tarea.

3 - Agregar la db al proyecto: 
    Crear una carpeta llamada DB y agregar el archivo, en este caso, tarea.db

Tabla tarea de la base de datos tarea.tb:
* id: autoincremental , pk, not null, int
* titulo: único, not null, text
* descripción: not null, text
* estado: not null, int

4 - Repositorio
 Instalar dependencia para utilizar SQLite con ADO.Net
 

- dotnet add package Microsoft.Data.SQLite

- agregar la configuración del proyecto en el  csproj

```xml
<ItemGroup>
    <None Update="DB\tarea.db">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
</ItemGroup>

- Implementar el patrón repositorio
* interfaz (donde definiremos las acciones que queremos que haga el repo)
* implementación de la interfaz (donde implemtamos como queremos que se realicen esas acciones)


Una vez que ya tenemos nuetros modelos y el acceso a datos, estamos en condiciones de crear el controlador
y sus respectivos endpoints.
Observación: luego realizaremos validaciones de los modelos utilizando viewmodels.

5 - Creal el controlador, en este caso, TareaController
* Como necesitamos acceder a los métodos del repo en el controlador , lo inyectamos.
Para poder realizar la inyeccion de dependencias debemos guardar la cadena de conexión 
a la db en el appsentings.json : 


```
"ConnectionStrings": {
    "SqliteConexion": "Data Source=Db/tarea.db;"
  }

  Luego en el program:
  Obtener la cadena de conexión e inyectarla:

-Obtenemos la cadena de conexión del appsettings.json:

```
  string CadenaDeConexion = builder.Configuration.GetConnectionString("SqliteConexion")!.ToString();

- Inyectamos la cadena de conexión:

```
  builder.Services.AddSingleton<string>(CadenaDeConexion);

- Inyectamos el repo:


  builder.Services.AddScoped<ITareaRepository, TareaRepository>();

* Una vez que ya tenemos configurada las dependencias en el programa, podemos inyectarla el repo en el controlador.

6 - Crear endpoints

7 - Probar



