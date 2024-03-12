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
    IRepositoryLess<Child> _child;

    [HttpGet]
    public async Task<PagedList<Child>> GetAllAsync([FromQuery] BaseQueryParams queryParams)
    {
        return await _child.GetAllAsync(queryParams);
    }
    [HttpGet("{id}")]
    public async Task<Child> GetSingleAsync(string id)
    {
        return await _child.GetSingleAsync(id);
    }
    [HttpPut("{id}")]
    public Task<Child> PutAsync(int id, Child item)
    {
        return _child.PutAsync(id, item);
    }

    [HttpPost]
    public async Task<Child> PostAsync(Child entity)
    {
        return await _child.PostAsync(entity);
    }

}
