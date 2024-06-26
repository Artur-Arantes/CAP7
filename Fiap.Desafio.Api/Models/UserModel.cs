namespace Fiap.Desafio.Api.Models;

public class UserModel
{
    public long Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public bool Enabled { get; set; }
    public bool SendNotification { get; set; }
    public string PersonId { get; set; }
    public PersonModel Person { get; set; }
    public ICollection<UserPermissionModel> UserPermissions { get; set; }
}