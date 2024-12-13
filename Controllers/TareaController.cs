using Microsoft.AspNetCore.Mvc;
namespace PracticaRecuperacion.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private readonly ITareaRepository _tareaRepository;

    public TareaController(ILogger<TareaController> logger, ITareaRepository tareaRepository)
    {
        _logger = logger;
        _tareaRepository = tareaRepository;
    }


    //Tener en cuenta a la hs de crear una tarea, que no se puede repetir el titulo.
    [HttpPost("/api/Tarea")]
    public ActionResult Create([FromBody]CreateTareaViewModels tarea_vm)
    {
        if (!ModelState.IsValid) return BadRequest("Faltan datos");
        Tarea tarea = new Tarea(tarea_vm);
        bool tareaCreada = _tareaRepository.CreateTarea(tarea);
        if (!tareaCreada) return BadRequest("No se pudo crear tarea");
        return Created();
    }

    [HttpGet("api/Tarea/{id}")]
    public ActionResult<GetTareaViewModels> GetTarea(int id)
    {
        if (id<0) return BadRequest("Ingrese un id valido");

        Tarea tarea = _tareaRepository.GetTarea(id);
        if (tarea is null) return NotFound("No se encontro la tarea");

        GetTareaViewModels tarea_vm = new GetTareaViewModels(tarea);
        return Ok(tarea_vm);
    }

    


}
