using AutoMapper;
using BirdApi.Data;
using BirdApi.Dto;
using BirdApi.Service.Abstract;
using BirdApi.Service.Base;
using FordApi.Base;

namespace BirdApi.Service.Concrete;

public class PersonService : BaseService<PersonDto, Person>, IPersonService
{
    private readonly IAccountService accountService;
    public PersonService(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IGenericRepository<Person> genericRepository) : base(unitOfWork, mapper, genericRepository)
    {
        this.accountService = accountService;
    }

    public override BaseResponse<bool> Insert(PersonDto insertResource)
    {
        if(insertResource.DateOfBirth.AddYears(18) > DateTime.UtcNow)
        {
            return new BaseResponse<bool>("Date of birth was incorrect.");
        }

        var response = accountService.GetByUsername(insertResource.Email);
        if(!response.Success)
        {
            return new BaseResponse<bool>(response.Message);
        }

        AccountDto account = response.Response;

        return base.Insert(insertResource);
    }
}
