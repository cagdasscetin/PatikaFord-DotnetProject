using BirdApi.Dto;
using BirdApi.Service.Abstract;
using BirdApi.Base;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BirdApi.Web.Controllers;

[Route("bird/api/v1.0/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService service;
    public PersonController(IPersonService service)
    {
        this.service = service;
    }


    [HttpGet("GetAll")]
    public BaseResponse<List<PersonDto>> GetAll()
    {
        Log.Debug("PersonController.GetAll");
        var response = service.GetAll();
        return response;
    }

    [HttpGet("{id}")]
    public BaseResponse<PersonDto> GetById(int id)
    {
        Log.Debug("PersonController.GetById");
        var response = service.GetById(id);
        return response;
    }

    [HttpPost]
    public BaseResponse<bool> Post([FromBody] PersonDto request)
    {
        Log.Debug("PersonController.Post");
        var response = service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public BaseResponse<bool> Put(int id, [FromBody] PersonDto request)
    {
        Log.Debug("PersonController.Put");
        request.Id = id;
        var response = service.Update(id, request);
        return response;
    }

    [HttpDelete("{id}")]
    public BaseResponse<bool> Delete(int id)
    {
        //Person person = this.service.PersonRepository.GetById(id);
        Log.Debug("PersonController.Delete");
        var response = service.Remove(id);
        return response;
    }
}
