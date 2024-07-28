namespace Agenda.Models;

public class Agendamento
{
    public int Id { get; set; }
    public string? NomeCliente { get; set; }
    public int IdadeCliente { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public Atendimento? Atendimento { get; set; }
}