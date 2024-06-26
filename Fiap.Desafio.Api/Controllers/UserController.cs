using AutoMapper;
using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Models;
using Fiap.Desafio.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Desafio.Api.Controllers;
[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _mapper = mapper;
        _userService = userService;
    }
    
    //TODO RETORNOS DE ERRO
    [HttpPost]
    public IActionResult add([FromBody]AddUserDto dto)
    {
        if (ModelState.IsValid)
        {
            UserModel userModel = new UserModel();
            userModel = _mapper.Map(dto, userModel);
            userModel.Person = _mapper.Map<PersonModel>(dto);
            _userService.Add(userModel);
        }
        return Ok();
    }
    
    //TODO FAZER OS RETORNOS DE ERRO
    [HttpGet]
    public IActionResult get(int id)
    {
        return Ok(_userService.Get(id));
    }
    
    
    //TODO ve que ta acontecendo aqui nesse endpoint
    [HttpDelete]
    public IActionResult delete(long id)
    {
        _userService.Delete(id);
        return Ok();
    }
}