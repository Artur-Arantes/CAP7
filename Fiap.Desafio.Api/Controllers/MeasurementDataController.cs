using AutoMapper;
using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Models;
using Fiap.Desafio.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Desafio.Api.Controllers;

[ApiController]
[Route("api/v1/data")]
[Authorize]
public class MeasurementDataController : Controller
{
    private readonly IMeasurementDataService _measurementDataService;
    private readonly IMapper _mapper;

    public MeasurementDataController(IMeasurementDataService measurementDataService, IMapper mapper)
    {
        _mapper = mapper;
        _measurementDataService = measurementDataService;
    }
    
    [HttpPost]
    public IActionResult add([FromBody]AddMeasureDto dto)
    {
        if (ModelState.IsValid)
        {
            RecordMeasurementModel record = new RecordMeasurementModel();
            record = _mapper.Map(dto, record);
            _measurementDataService.Add(record);
        }
        return Ok();
    }
    
    //TODO IMPLEMENTAR UM GETALL POR LOCATION COM PAGINACAO
    
}