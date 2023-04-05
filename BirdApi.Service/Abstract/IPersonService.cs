using BirdApi.Data;
using BirdApi.Dto;
using BirdApi.Service.Base;

namespace BirdApi.Service.Abstract;

public interface IPersonService : IBaseService<PersonDto, Person>
{

}
