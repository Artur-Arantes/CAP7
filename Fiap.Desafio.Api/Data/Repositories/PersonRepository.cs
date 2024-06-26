
using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public class PersonRepository: IPersonRepository
{
    private readonly DatabaseContext _databaseContext;

    public PersonRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public IEnumerable<PersonModel> GetAll()
    {
        return _databaseContext.PersonModels.ToList();
    }

    public PersonModel GetById(String id)
    {
        return _databaseContext.PersonModels.Find(id);
    }

    public void add(PersonModel personModel)
    {
        _databaseContext.PersonModels.Add(personModel);
        _databaseContext.SaveChanges();
    }

    public void update(PersonModel personModel)
    {
        _databaseContext.PersonModels.Update(personModel);
        _databaseContext.SaveChanges();
    }

    public void delete(PersonModel personModel)
    {
        _databaseContext.PersonModels.Remove(personModel);
        _databaseContext.SaveChanges();
    }
}