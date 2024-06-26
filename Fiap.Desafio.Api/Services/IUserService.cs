using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Services;

public interface IUserService
{
    public void Add(UserModel user);
    public UserModel Get(long id);

    public Boolean IsLoginAuthorized(LoginDto loginDto);

    public void Delete(long id);
}