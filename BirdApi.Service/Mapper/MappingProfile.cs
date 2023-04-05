using AutoMapper;
using BirdApi.Data;
using BirdApi.Dto;

namespace BirdApi.Service;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<PersonDto, Person>();

        CreateMap<Account, AccountDto>();
        CreateMap<AccountDto, Account>();
    }
}
