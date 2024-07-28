namespace Agenda.Models;

public class Horario
{
    public int Id { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFim { get; set; }
    public int IntervaloAgendamento { get; set; }
    public int DiaSemana { get; set; }
}