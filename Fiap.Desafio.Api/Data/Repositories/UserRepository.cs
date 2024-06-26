using Fiap.Desafio.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Desafio.Api.Data.Repositories;

public class UserRepository : IUserRepository
{   
    private readonly DatabaseContext _databaseContext;

    public UserRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public void Add(UserModel userModel)
    {
        _databaseContext.Add(userModel);
        _databaseContext.SaveChanges();
    }

    public void Update(UserModel user)
    {
        _databaseContext.Update(user);
        _databaseContext.SaveChanges();
    }

    public UserModel GetById(long id)
    {
        return _databaseContext.UserModels.Find(id);
    }

    public UserModel getByPerson(PersonModel personModel)
    {
        return _databaseContext.UserModels
            .Include(u => u.Person) // Inclua se houver uma relação de navegação entre UserModel e PersonModel
            .FirstOrDefault(u => u.PersonId == personModel.Email);
    }

    public void delete(long id)
    {
        _databaseContext.Remove(id);
        _databaseContext.SaveChanges();
    }
}