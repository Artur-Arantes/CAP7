using AutoMapper;
using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Models;
using Fiap.Desafio.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Desafio.Api.Controllers;

[ApiController]
[Route("api/v1/index")]
public class IndexController : Controller
{
    
    private readonly IIndexService _indexService;
    private readonly IMapper _mapper;

    public IndexController(IIndexService indexService, IMapper mapper)
    {
        _mapper = mapper;
        _indexService = indexService;
    }
    //TODO ajeitar esse endpoint
    [HttpPost]
    public IActionResult add([FromBody]AddIndexDto dto)
    {
        if (ModelState.IsValid)
        {   
            //TODO MAPEAR NO _IMAPPER
            ResourceIndexModel model = new ResourceIndexModel();
            model.IndexMinimum = dto.Min;
            model.IndexNormal = dto.Normal;
            model.IndexMaximum = dto.Max;
            model.ResourceId = dto.ResourceId;
            ResourceModel resource = new ResourceModel();
            resource.Id = dto.ResourceId;
            resource.Name = dto.Name;
            model.Resource = resource;
            
            _indexService.add(model);
        }
        return Ok();
    }
}