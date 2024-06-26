using Fiap.Desafio.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Desafio.Api.Data.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PermissionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void add(PermissionModel permissionModel)
        {
            _databaseContext.PermissionModels.Add(permissionModel);
        }

        public PermissionModel get(PermissionModel permissionModel)
        {
            return _databaseContext.PermissionModels.FirstOrDefault(p => p.Name == permissionModel.Name);
        }
    }
}