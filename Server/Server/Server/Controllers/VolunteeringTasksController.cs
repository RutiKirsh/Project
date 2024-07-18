using Bl;
using Bl.BlApi;
using Bl.Models;
using Common;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VolunteeringTasksController : ControllerBase
{
    IVolunteeringTaskService _volunteeringTasksRepository;
    public VolunteeringTasksController(BlManager manager)
    {
        this._volunteeringTasksRepository = manager.voluteeringTaskService;
    }
    [HttpGet]
    public async Task<PagedList<BlVolunteeringTask>> GetAllAsync([FromQuery] BaseQueryParams queryParams)
    {
        return await _volunteeringTasksRepository.GetAllAsync(queryParams);
    }

    [HttpGet("{email}/{password}")]
    public async Task<PagedList<ExtendsVolunteeringTask>> GetAllAsync([FromQuery] BaseQueryParams queryParams, string email, string password)
    {
        var res = await _volunteeringTasksRepository.GetAllAsync(queryParams, email, password);
        return res;
    }
    [HttpGet("{id}/{email}/{password}")]
    public async Task<BlVolunteeringTask> GetSingleAsync(int id, string email, string password)
    {
        return await _volunteeringTasksRepository.GetSingleAsync(id, email, password);
    }
    [HttpPost("{email}/{password}")]
    public async Task<BlVolunteeringTask> PostAsync(PostTask entity, string email, string password)
    {
        return await _volunteeringTasksRepository.PostAsync(entity, email, password);
    }
    [HttpPut("{id}")]
    public async Task<BlVolunteeringTask> PutAsync([FromQuery] BlVolunteeringTask item, [FromBody] BlUser user)
    {
        return await _volunteeringTasksRepository.PutAsync(item, user);
    }
    [HttpPut("do/{id}/{email}/{password}")]
    public async Task<BlVolunteeringTask> DoTsakAsync(int id, string email, string password)
    {
        return await _volunteeringTasksRepository.DoTaskAsync(id, email, password);
    }
    [HttpDelete("{id}/{email}/{password}")]
    public async Task<BlVolunteeringTask> DeleteAsync(int id, string email, string password)
    {
        return await _volunteeringTasksRepository.DeleteAsync(id, email, password);
    }



}
