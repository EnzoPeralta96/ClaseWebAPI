using Microsoft.AspNetCore.Mvc;
namespace PracticaRecuperacion.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private readonly TareaRepository _tareaRepository;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        _tareaRepository = new TareaRepository("Data Source=DB/tarea.db;Cache=Shared");
    }


    //Tener en cuenta a la hs de crear una tarea, que no se puede repetir el titulo.
    [HttpPost("/api/Tarea")]
    public ActionResult<Tarea> Create([FromBody]Tarea tarea)
    {
        bool tareaCreada = _tareaRepository.CreateTarea(tarea);
        if (!tareaCreada) return BadRequest("No se pudo crear tarea");
        return Created();
    }

    [HttpGet("api/Tarea/{id}")]
    public ActionResult<Tarea> GetTarea(int id)
    {
        Tarea tarea = _tareaRepository.GetTarea(id);
        if (tarea is null) return NotFound("No se encontro la tarea");
        return Ok(tarea);
    }



}
