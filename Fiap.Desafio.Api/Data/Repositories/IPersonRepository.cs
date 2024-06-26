
using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public interface IPersonRepository
{
    IEnumerable<PersonModel> GetAll();

    PersonModel GetById(String email);

    void add(PersonModel personModel);

    void update(PersonModel personModel);

    void delete(PersonModel personModel);
}