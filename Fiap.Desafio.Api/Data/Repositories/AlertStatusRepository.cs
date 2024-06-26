using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public class AlertStatusRepository : IAlertStatusRepository
{   
    private readonly DatabaseContext _databaseContext;

    public AlertStatusRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public void Add(AlertStatusModel model)
    {
        _databaseContext.Add(model);
        _databaseContext.SaveChanges();
    }
}