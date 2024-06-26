namespace Fiap.Desafio.Api.Models;

public class UserPermissionModel
{
    public long UserId { get; set; }
    public UserModel User { get; set; }
    public long PermissionId { get; set; }
    public PermissionModel Permission { get; set; }

}