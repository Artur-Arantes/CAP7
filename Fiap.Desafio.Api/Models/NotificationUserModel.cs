namespace Fiap.Desafio.Api.Models;

public class NotificationUserModel
{
    public UserModel? User { get; set; }
    public AlertStatusModel Alert { get; set; }
}