using Agenda.Models;
using Agenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers;

[ApiController]
[Route("[Controller]")]
public class AtendimentosController : ControllerBase
{
    private readonly AtendimentoService _service;

    public AtendimentosController(AtendimentoService service)
    {
        _service = service;
    }

    [HttpGet()]
    public List<Atendimento> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Atendimento> Get(int id)
    {
        Atendimento? atendimento = _service.Get(id);
        if (atendimento is null)
        {
            return NotFound();
        }

        return atendimento;
    }

    [HttpPost]
    public ActionResult<Atendimento> Create(Atendimento atendimento)
    {
        Atendimento atendimentoCriado = _service.Create(atendimento);
        return CreatedAtAction(nameof(Get), new { id = atendimentoCriado.Id }, atendimentoCriado);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Atendimento atendimento)
    {
        try
        {
            _service.Update(id, atendimento);
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