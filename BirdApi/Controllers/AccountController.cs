using BirdApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdApi.Web.Controllers;

[Route("bird/api/v1.0/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;

	public AccountController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	[HttpGet("GetAll")]
	public List<Account> GetAll()
	{
		List<Account> accountList = _unitOfWork.AccountRepository.GetAll();
		return accountList;
	}

	[HttpGet("{id}")]
	public Account GetById(int id)
	{
		Account account = _unitOfWork.AccountRepository.GetById(id);
		return account;
	}
}
