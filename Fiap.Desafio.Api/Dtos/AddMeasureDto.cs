namespace Fiap.Desafio.Api.Dtos;

public class AddMeasureDto
{
    public long ResourceID { get; set; }
    public String Location { get; set; }
    public Double Measurement { get; set;}
    public String DateTime { get; set; }
}