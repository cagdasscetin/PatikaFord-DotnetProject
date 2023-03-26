using BirdApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdApi.Web.Controllers;

[Route("bird/api/v1.0/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
	public PersonController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	[HttpGet("GetAll")]
	public List<Person> GetAll()
	{
		List<Person> personList = _unitOfWork.PersonRepository.GetAll();
		return personList;
	}

	[HttpGet("{id}")]
	public Person GetById(int id)
	{
		Person person = _unitOfWork.PersonRepository.GetById(id);
		return person;
	}

	[HttpPost]
	public void Post([FromBody] Person request)
	{
		_unitOfWork.PersonRepository.Insert(request);
		_unitOfWork.Complete();
	}

	[HttpPut("{id}")]
	public void Put(int id, [FromBody] Person request)
	{
		request.Id = id;
		_unitOfWork.PersonRepository.Update(request);
		_unitOfWork.Complete();
	}

	[HttpDelete("{id}")]
	public void Delete(int id)
	{
		//Person person = _unitOfWork.PersonRepository.GetById(id);
		_unitOfWork.PersonRepository.Remove(id);
		_unitOfWork.Complete();
	}
}
