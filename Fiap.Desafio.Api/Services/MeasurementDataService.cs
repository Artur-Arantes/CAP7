using Fiap.Desafio.Api.Data;
using Fiap.Desafio.Api.Data.Repositories;
using Fiap.Desafio.Api.Models;

namespace Fiap.Desafio.Api.Services;

public class MeasurementDataService : IMeasurementDataService
{
    
    private IResourceRepository _resourceRepository;
    private IResourceIndexRepository _resourceIndexRepository;
    private IMeasureRepository _measureRepository;
    private readonly DatabaseContext _databaseContext;

    public MeasurementDataService(DatabaseContext databaseContext, IResourceRepository resourceRepository,
        IResourceIndexRepository resourceIndexRepository, IMeasureRepository measureRepository)
    {
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
        if (record.Measurement > index.IndexMaximum)
        {
            
            //TODO enviar e-mail ou printa na tela 
        }else if (record.Measurement <= index.IndexMinimum)
        {
            //TODO enviar e-mail ou printa na tela 
        }
    }
}