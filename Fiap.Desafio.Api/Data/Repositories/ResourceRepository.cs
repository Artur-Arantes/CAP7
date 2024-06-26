using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public class ResourceRepository:IResourceRepository
{   
    private readonly DatabaseContext _databaseContext;

    public ResourceRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public ResourceModel findById(long id)
    {
        return _databaseContext.ResourceModels.Find(id);
        
    }

    public void add(ResourceModel resourceModel)
    {
        _databaseContext.Add(resourceModel);
        _databaseContext.SaveChanges();
    }
}