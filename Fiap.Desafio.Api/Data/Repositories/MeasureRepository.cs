using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public class MeasureRepository : IMeasureRepository
{
    
    private readonly DatabaseContext _databaseContext;

    public MeasureRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public void add(RecordMeasurementModel record)
    {
        _databaseContext.RecordMeasurementModels.Add(record);
        _databaseContext.SaveChanges();
    }
}