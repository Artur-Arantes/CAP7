using Fiap.Desafio.Api.Data;
using Fiap.Desafio.Api.Data.Repositories;
using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Services;

public class MeasurementDataService : IMeasurementDataService
{
    
    private IResourceRepository _resourceRepository;
    private IResourceIndexRepository _resourceIndexRepository;
    private IMeasureRepository _measureRepository;
    private IAlertStatusRepository _alertStatusRepository;
    private readonly DatabaseContext _databaseContext;

    public MeasurementDataService(DatabaseContext databaseContext, IResourceRepository resourceRepository,
        IResourceIndexRepository resourceIndexRepository, IMeasureRepository measureRepository, IAlertStatusRepository
            alertStatusRepository)
    {
        _alertStatusRepository = alertStatusRepository;
        _resourceRepository = resourceRepository;
        _databaseContext = databaseContext;
        _resourceIndexRepository = resourceIndexRepository;
        _measureRepository = measureRepository;
    }

    public void Add(RecordMeasurementModel record)
    {
        ResourceModel resource = _resourceRepository.findById(record.ResourceId);
        ResourceIndexModel resourceIndex = _resourceIndexRepository.findById(resource.Id);
        
        _measureRepository.add(record);

        GetIndexMeasure(resourceIndex,record);
    }

    private void GetIndexMeasure( ResourceIndexModel index, RecordMeasurementModel record)
    {
        AlertStatusModel alert = null;
        if (record.Measurement > index.IndexMaximum)
        {
            alert = new AlertStatusModel();
            alert.DateTimeAlert = DateTime.Now;
            alert.Status = "Index above the maximum";
            alert.SendNotification = true;
            alert.Description = "run !!";
            alert.IdRecord = record.Id;
        }else if (record.Measurement <= index.IndexMinimum)
        {
            alert = new AlertStatusModel();
            alert.DateTimeAlert = DateTime.Now;
            alert.Status = "Index under the minimum";
            alert.SendNotification = true;
            alert.Description = "run !!";
            alert.IdRecord = record.Id;
        }

        if (alert != null)
        {
            _alertStatusRepository.Add(alert);
        }
    }
}