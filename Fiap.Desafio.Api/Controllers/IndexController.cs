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
    [HttpPost]
    public IActionResult Add([FromBody]AddIndexDto dto)
    {
        if (ModelState.IsValid)
        {
            var model = _mapper.Map<ResourceIndexModel>(dto);
            _indexService.Add(model);
            return Ok();
        }

        return BadRequest(ModelState);
    }
}