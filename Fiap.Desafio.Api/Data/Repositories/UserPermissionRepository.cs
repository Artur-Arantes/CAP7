using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public class UserPermissionRepository: IUserPermissionRepository
{   
    private readonly DatabaseContext _databaseContext;

    public UserPermissionRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public void add(UserPermissionModel userPermissionModel)
    {
        _databaseContext.UserPermissionModels.Add(userPermissionModel);
        _databaseContext.SaveChanges();
    }
}