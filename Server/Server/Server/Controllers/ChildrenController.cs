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
    public async Task<List<Child>> GetAllAsync()
    {
        return await _child.GetAllAsync();
    }
    [HttpGet]
    public async Task<Child> GetSingleAsync(string id)
    {
        return await _child.GetSingleAsync(id);
    }
    [HttpPut]
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
