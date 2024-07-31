using Agenda.Data;
using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Services;

public class HorarioService
{
    private readonly AgendaContext _context;

    public HorarioService(AgendaContext context)
    {
        _context = context;
    }
    
    public List<Horario> GetAll()
    {
        return _context.Horarios
            .AsNoTracking()
            .ToList();
    }
    
    public Horario? Get(int id)
    {
        return _context.Horarios
            .AsNoTracking()
            .SingleOrDefault(h => h.Id == id);
    }

    public Horario Create(Horario novoHorario)
    {
        _context.Horarios.Add(novoHorario);
        _context.SaveChanges();
        return novoHorario;
    }

    public void Update(int id, Horario input)
    {
        Horario? horario = _context.Horarios.Find(id);
        if (horario is null)
        {
            throw new InvalidOperationException("Horário não existe");
        }
        horario.HoraInicio = input.HoraInicio;
        horario.HoraFim = input.HoraFim;
        horario.DiaSemana = input.DiaSemana;
        horario.IntervaloAgendamento = input.IntervaloAgendamento;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Horario? horario = _context.Horarios.Find(id);
        if (horario is null)
        {
            throw new InvalidOperationException("Horário não existe");
        }
        _context.Horarios.Remove(horario);
        _context.SaveChanges();    
    }
}