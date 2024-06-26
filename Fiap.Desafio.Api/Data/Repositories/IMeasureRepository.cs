using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public interface IMeasureRepository
{
    void add(RecordMeasurementModel record);

}