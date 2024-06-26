using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public interface IUserPermissionRepository
{
    void add(UserPermissionModel userPermissionModel);
}