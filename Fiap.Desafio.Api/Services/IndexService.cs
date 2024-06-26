using Fiap.Desafio.Api.Data;
using Fiap.Desafio.Api.Data.Repositories;
using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Services;

public class IndexService : IIndexService
{
    
    private readonly DatabaseContext _databaseContext;
    private readonly IResourceIndexRepository _repository;
    private readonly IResourceRepository _resourceRepository;
    
    public IndexService(DatabaseContext databaseContext, IResourceIndexRepository repository,
        IResourceRepository resourceRepository)
    {
        _databaseContext = databaseContext;
        _repository = repository;
        _resourceRepository = resourceRepository;
    } 
    
    public void add(ResourceIndexModel index)
    {
        _resourceRepository.add(index.Resource);
        _repository.add(index);
        
    }
}