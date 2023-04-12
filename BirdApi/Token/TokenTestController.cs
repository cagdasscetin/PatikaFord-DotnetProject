using BirdApi.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BirdApi.Web.Token;

[Route("bird/api/v1.0/[controller]")]
[ApiController]
public class TokenTestController : ControllerBase
{
    public TokenTestController()
    {
        
    }

    [HttpGet("NoToken")]
    public string NoToken()
    {
        return "NoToken";
    }

    [HttpGet("Authorize")]
    [Authorize]
    public string Authorize()
    {
        return "Authorize";
    }

    [HttpGet("Admin")]
    [Authorize(Roles = Role.Admin)]
    public string Admin()
    {
        return "Admin";
    }

    [HttpGet("Viewer")]
    [Authorize(Roles = Role.Viewer)]
    public string Viewer()
    {
        return "Viewer";
    }

    [HttpGet("AdminViewer")]
    [Authorize(Roles = $"{Role.Admin},{Role.Viewer}")]
    public string AdminViewer()
    {
        return "AdminViewer";
    }

    [HttpGet("EditorQTNSEditorQTDA")]
    [Authorize(Roles = $"{Role.EditorQTNS},{Role.EditorQTDA}")]
    public string EditorQTNSEditorQTDA()
    {
        return "EditorQTNSEditorQTDA";
    }

    [HttpGet("TestAccount")]
    [Authorize]
    public string TestAccount()
    {
        var claimsList = User.Claims;

        var account = claimsList.Where(x => x.Type == "AccountId").FirstOrDefault();
        var accountId = account.Value;

        var url = HttpContext.Request.Path;

        var id = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;

        return "TestAccount";
    }
}
