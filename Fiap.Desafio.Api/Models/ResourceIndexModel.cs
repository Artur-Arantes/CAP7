namespace Fiap.Desafio.Api.Models;

public class ResourceIndexModel
{
    public Double IndexMinimum { get; set; }
    public Double IndexNormal { get; set; }
    public Double IndexMaximum { get; set; }
    public ResourceModel? Resource { get; set; }
    public long ResourceId { get; set; }
    
}