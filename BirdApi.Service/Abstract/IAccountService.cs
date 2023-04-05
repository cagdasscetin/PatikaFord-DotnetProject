using BirdApi.Data;
using BirdApi.Dto;
using BirdApi.Service.Base;
using FordApi.Base;

namespace BirdApi.Service.Abstract;

public interface IAccountService : IBaseService<AccountDto, Account>
{
    BaseResponse<AccountDto> GetByUsername(string name);
}
