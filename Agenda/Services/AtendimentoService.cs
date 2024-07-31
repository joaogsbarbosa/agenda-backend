using Agenda.Data;
using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Services;

public class AtendimentoService
{
    private readonly AgendaContext _context;

    public AtendimentoService(AgendaContext context)
    {
        _context = context;
    }

    public List<Atendimento> GetAll()
    {
        return _context.Atendimentos
            .AsNoTracking()
            .ToList();
    }

    public Atendimento? Get(int id)
    {
        return _context.Atendimentos
            .AsNoTracking()
            .SingleOrDefault(a => a.Id == id);
    }

    public Atendimento Create(Atendimento atendimento)
    {
        _context.Atendimentos.Add(atendimento);
        _context.SaveChanges();
        return atendimento;
    }

    public void Update(int id, Atendimento input)
    {
        Atendimento? toUpdate = _context.Atendimentos.Find(id);
        if (toUpdate is null)
        {
            throw new InvalidOperationException("Atendimento não encontrado");
        }

        toUpdate.Nome = input.Nome;
        toUpdate.Duracao = input.Duracao;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Atendimento? atendimento = _context.Atendimentos.Find(id);
        if (atendimento is null)
        {
            throw new InvalidOperationException("Atendimento não encontrado");
        }

        _context.Remove(atendimento);
        _context.SaveChanges();
    }
}