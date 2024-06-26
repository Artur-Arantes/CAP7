using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public interface IResourceRepository
{
    ResourceModel findById(long id);

    void add(ResourceModel resourceModel);
}