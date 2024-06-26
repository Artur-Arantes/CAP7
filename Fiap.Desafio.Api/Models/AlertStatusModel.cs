namespace Fiap.Desafio.Api.Models;

public class AlertStatusModel
{
    public long Id { get; set; }
    public string Description { get; set; }
    public DateTime DateTimeAlert { get; set; }
    public bool SendNotification { get; set; }
    public string Status { get; set; }
    public long IdRecord { get; set; }

    public RecordMeasurementModel? RecordMeasurement { get; set; }
}