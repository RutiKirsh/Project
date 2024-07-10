using Bl;
using Bl.BlApi;
using Bl.Models;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChildrenController : ControllerBase
{
    IChildService _child;
    public ChildrenController(BlManager manager)
    {
        this._child = manager.child;
    }

    [HttpGet("{id}")]
    public async Task<BlChild> GetSingleAsync(string id, [FromQuery]string email, [FromQuery] string pass)
    {
        return await _child.GetSingleAsync(id, email, pass);
    }

    [HttpPut("{id}")]
    public async Task<BlChild> PutAsync([FromQuery] BlChild item, [FromBody]BlUser user)
    {
        return await _child.PutAsync(item, user);
    }

    [HttpPost]
    public async Task<BlChild> PostAsync(PostChild entity)
    {
        return await _child.PostAsync(entity);
    }

}
