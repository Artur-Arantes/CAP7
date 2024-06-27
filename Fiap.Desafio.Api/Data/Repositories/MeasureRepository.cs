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

    public List<RecordMeasurementModel> GetAllByLocation(string location, int pageNumber, int pageSize)
    {
        return _databaseContext.RecordMeasurementModels
            .Where(r => r.Location == location)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}