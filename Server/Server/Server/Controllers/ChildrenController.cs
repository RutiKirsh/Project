using Bl;
using Bl.BlApi;
using Bl.Models;
using Common;
using Dal.DalApi;
using Dal.DalImplementation;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChildrenController : ControllerBase
{
    IRepo<Child> _child;
    public ChildrenController(BlManager manager)
    {
        this._child = manager.child;
    }

    [HttpGet]
    public async Task<PagedList<Child>> GetAllAsync([FromQuery] BaseQueryParams queryParams)
    {
        return await _child.GetAllAsync(queryParams);
    }
    [HttpGet("{id}")]
    public async Task<Child> GetSingleAsync(string id, BlUser user)
    {
        return await _child.GetSingleAsync(id, user);
    }
    [HttpPut("{id}")]
    public Task<Child> PutAsync(Child item, BlUser user)
    {
        return _child.PutAsync(item, user);
    }

    [HttpPost]
    public async Task<Child> PostAsync(Child entity)
    {
        return await _child.PostAsync(entity);
    }

}
