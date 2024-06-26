namespace Fiap.Desafio.Api.Dtos;

public class AddIndexDto
{
    public long ResourceId { get; set;}
    public double Min { get; set;}
    public double Normal { get; set; }
    public double Max { get; set; }
    public String Name { get; set; }
    
    public String UnityOfMeasure { get; set; }
}