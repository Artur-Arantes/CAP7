namespace Fiap.Desafio.Api.Models;

public class RecordMeasurementModel
{
    public long Id { get; set; }
    public String Location { get; set; }
    public Double Measurement { get; set; }
    public String DateTime { get; set; }
    public ResourceModel ? Resource { get; set; }
    public long ResourceId { get; set; }
    
    public ICollection<AlertStatusModel> AlertStatuses { get; set; } = new List<AlertStatusModel>();
}