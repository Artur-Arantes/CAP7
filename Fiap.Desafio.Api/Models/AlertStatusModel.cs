namespace Fiap.Desafio.Api.Models;

public class AlertStatusModel
{
    public long Id { get; set; }
    public String Description { get; set; }
    public DateTime DateTimeAlert { get; set; }
    public Boolean SendNotification { get; set; }
    public String Status { get; set; }
}