using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Data.Repositories;

public interface IAlertStatusRepository
{
    void Add(AlertStatusModel model);
}