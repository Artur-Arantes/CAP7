using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public interface IPermissionRepository
{
    void add(PermissionModel permissionModel);

    PermissionModel get(PermissionModel permissionModel);
}