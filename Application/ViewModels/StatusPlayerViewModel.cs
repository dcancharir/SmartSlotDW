namespace Application.ViewModels;
public class StatusPlayerViewModel
{
    public int idStatus { get; set; }
    public string? nombrecompleto { get; set; }
    public string? dni { get; set; }
    public string? maquina { get; set; }
    public DateTime fechaini { get; set; }
    public DateTime fechafin { get; set; }
    public double token { get; set; }
    public int puntos { get; set; }
    public int coinin { get; set; }
    public int coinout { get; set; }
    public int jackpot { get; set; }
    public List<StatusMaquinaCuponViewModel> statusMaquinaCupon { get; set; } = null!;
}
