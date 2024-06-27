using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public interface IMeasureRepository
{
    void add(RecordMeasurementModel record);

    public List<RecordMeasurementModel> GetAllByLocation(string location, int pageNumber, int pageSize);

}