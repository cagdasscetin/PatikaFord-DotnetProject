﻿using BirdApi.Dto;
using BirdApi.Service.Abstract;
using FordApi.Base;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BirdApi.Web.Controllers;

[Route("bird/api/v1.0/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService service;
    public AccountController(IAccountService service)
    {
        this.service = service;
    }


    [HttpGet("GetAll")]
    public BaseResponse<List<AccountDto>> GetAll()
    {
        Log.Debug("AccountController.GetAll");
        var response = service.GetAll();
        return response;
    }

    [HttpGet("/GetByUsername/{username}")]
    public BaseResponse<AccountDto> GetByUsername([FromRoute] string username)
    {
        Log.Debug("AccountController.GetByUsername");
        var response = service.GetByUsername(username);
        return response;
    }
    
    [HttpGet("/GetById/{id}")]
    public BaseResponse<AccountDto> GetById(int id)
    {
        Log.Debug("AccountController.GetById");
        var response = service.GetById(id);
        return response;
    }

    [HttpPost]
    public BaseResponse<bool> Post([FromBody] AccountDto request)
    {
        Log.Debug("AccountController.Post");
        var response = service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public BaseResponse<bool> Put(int id, [FromBody] AccountDto request)
    {
        Log.Debug("AccountController.Put");
        request.Id = id;
        var response = service.Update(id, request);
        return response;
    }

    [HttpDelete("{id}")]
    public BaseResponse<bool> Delete(int id)
    {
        //Account Account = this.service.AccountRepository.GetById(id);
        Log.Debug("AccountController.Delete");
        var response = service.Remove(id);
        return response;
    }
}
