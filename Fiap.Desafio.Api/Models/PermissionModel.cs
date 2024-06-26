namespace Fiap.Desafio.Api.Models;

public class PermissionModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserPermissionModel> UserPermissions { get; set; }

}