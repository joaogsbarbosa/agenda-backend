namespace Agenda.Models;

public class Atendimento
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int Duracao { get; set; }
    public bool ClientePodeAgendar { get; set; }
}