using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public interface IResourceIndexRepository
{
    ResourceIndexModel findById(long id);

    void add(ResourceIndexModel resourceIndexModel);
}