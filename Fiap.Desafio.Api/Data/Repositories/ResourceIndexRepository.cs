using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public class ResourceIndexRepository : IResourceIndexRepository
{
    
    private readonly DatabaseContext _databaseContext;

    public ResourceIndexRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public ResourceIndexModel findById(long id)
    {
        return _databaseContext.ResourceIndexModels.Find(id);
    }

    public void add(ResourceIndexModel resourceIndexModel)
    {
        _databaseContext.Add(resourceIndexModel);
        _databaseContext.SaveChanges();
    }
}