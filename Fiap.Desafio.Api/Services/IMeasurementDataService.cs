using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Services;

public interface IMeasurementDataService
{
    void Add(RecordMeasurementModel record);

    public List<RecordMeasurementModel> GetAllByLocation(string location, int pageNumber, int pageSize);
}