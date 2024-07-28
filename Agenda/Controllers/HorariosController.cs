using Agenda.Models;
using Agenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers;

[ApiController]
[Route("[Controller]")]
public class HorariosController : ControllerBase
{
    private readonly HorarioService _service;

    public HorariosController(HorarioService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public List<Horario> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Horario> Get(int id)
    {
        Horario? horario = _service.Get(id);
        if (horario is null)
        {
            return NotFound();
        }
        return horario;
    }

    [HttpPost]
    public ActionResult Create(Horario novoHorario)
    {
        Horario horario = _service.Create(novoHorario);
        return CreatedAtAction(nameof(Get), new { id = horario.Id }, horario);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Horario horario)
    {
        try
        {
            _service.Update(id, horario);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            _service.Delete(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
        return Ok();
    }
}