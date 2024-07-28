using Agenda.Models;

namespace Agenda.Data;

public static class DbInitializer
{
    public static void Initialize(AgendaContext context)
    {
        if (context.Agendamentos.Any() && context.Atendimentos.Any() && context.Horarios.Any())
        {
            return;
        }

        Horario[] horarios = new Horario[]
        {
            new Horario
            {
                DiaSemana = 2,
                HoraInicio = TimeOnly.Parse("09:00"),
                HoraFim = TimeOnly.Parse("12:00"),
                IntervaloAgendamento = 30
            },
            new Horario
            {
                DiaSemana = 2,
                HoraInicio = TimeOnly.Parse("13:00"),
                HoraFim = TimeOnly.Parse("18:00"),
                IntervaloAgendamento = 15
            },
            new Horario
            {
                DiaSemana = 6,
                HoraInicio = TimeOnly.Parse("06:00"),
                HoraFim = TimeOnly.Parse("12:00"),
                IntervaloAgendamento = 60
            }
        };
        context.Horarios.AddRange(horarios);

        Atendimento[] atendimentos = new Atendimento[]
        {
            new Atendimento
            {
                Nome = "Consulta",
                Duracao = 15,
                ClientePodeAgendar = true
            },
            new Atendimento
            {
                Nome = "Exame de rotina",
                Duracao = 30,
                ClientePodeAgendar = true
            },
            new Atendimento
            {
                Nome = "Cirurgia",
                Duracao = 60,
                ClientePodeAgendar = false
            }
        };
        context.Atendimentos.AddRange(atendimentos);

        context.SaveChanges();
    }
}