
public class Agenda{
    public string AgendaId { get; set; } = Guid.NewGuid().ToString();
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public string? Contato { get; set; }
    public string? Status { get; set; } = "Não iniciada";
}