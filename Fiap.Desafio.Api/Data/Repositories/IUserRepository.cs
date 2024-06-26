using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public interface IUserRepository
{
    void Add(UserModel userModel);
    void Update(UserModel user);

    UserModel GetById(long id);
    UserModel getByPerson(PersonModel personModel);
    void delete(long id);
}