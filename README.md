# ClaseWebAPI
Implementación de una API REST FULL con C# y el framework de .NET

Pasos para implementar la API:
1 - crear el template de la web api con ASP
● (versión 7): dotnet new webapi
● (versión 8+): dotnet new webapi --use-controller

2) Crear los modelos necesarios, esta caso el modelo Tarea.

3) Agregar la db al proyecto: 
Crear una carpeta llamada DB y agregar el archivo, en este caso, tarea.db

/* Tabla tarea de la base de datos tarea.tb 
id: autoincremental , pk, not null, int
titulo: único, not null, text
descripción: not null, text
estado: not null, int

4) Instalar dependencia para utilizar SQLite con ADO.Net
● dotnet add package Microsoft.Data.SQLite

● agregar la configuración del proyecto en el  csproj
<ItemGroup>
    <None Update="DB\tarea.db">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
</ItemGroup>

3) Implementar el patrón repositorio
● interfaz (donde definiremos las acciones que queremos que haga el repo)
● implementación de la interfaz (donde implemtamos como queremos que se realicen esas acciones)

Una vez que ya tenemos nuetros modelos y el acceso a datos, estamos en condiciones de crear el controlador
y sus respectivos endpoints.
Observación: luego realizaremos validaciones de los modelos utilizando viewmodels.

4) Creal el controlador, en este caso, TareaController
- Como necesitamos acceder a los métodos del repo en el controlador, los instanciamos en un principio.
- Inicialmente instanciamos el repo, luego implementamos la inyección de dependencias.
● Instanciar el repo, indicando la cadena de conexión: Data Source=DB/nombre_db;Cache=Shared

5) Crear endpoints

6) Probar



