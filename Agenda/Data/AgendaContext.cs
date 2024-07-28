using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data;

public class AgendaContext: DbContext
{
    public AgendaContext(DbContextOptions<AgendaContext> options): base(options)
    {
    }
    public DbSet<Horario> Horarios => Set<Horario>();
    public DbSet<Atendimento> Atendimentos => Set<Atendimento>();
    public DbSet<Agendamento> Agendamentos => Set<Agendamento>();
}