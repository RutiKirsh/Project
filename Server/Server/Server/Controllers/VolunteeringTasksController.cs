using Bl.BlApi;
using Bl.Models;
using Common;
using Dal.DalApi;
using Dal.DalImplementation;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VolunteeringTasksController : ControllerBase
{
    IVolunteeringTaskRepo _volunteeringTasksRepository;
    public VolunteeringTasksController(IVolunteeringTaskRepo repository)
    {
        this._volunteeringTasksRepository = repository;
    }
    [HttpGet]
    public async Task<PagedList<TaskList>> GetAllAsync([FromQuery] BaseQueryParams queryParams)
    {
        return await _volunteeringTasksRepository.GetAllAsync(queryParams);
    }
    [HttpGet("{id}")]
    public async Task<BlVolunteeringTask> GetSingleAsync(int id, [FromBody] BlUser user)
    {
        return await _volunteeringTasksRepository.GetSingleAsync(id, user);
    }
    [HttpPost]
    public async Task<BlVolunteeringTask> PostAsync(BlVolunteeringTask entity)
    {
        return await _volunteeringTasksRepository.PostAsync(entity);
    }
    [HttpPut("{id}")]
    public async Task<BlVolunteeringTask> PutAsync(BlVolunteeringTask item, [FromBody] BlUser user)
    {
        return await _volunteeringTasksRepository.PutAsync(item, user);
    }
    [HttpDelete("{id}")]
    public async Task<BlVolunteeringTask> DeleteAsync(int id)
    {
        return await _volunteeringTasksRepository.DeleteAsync(id);
    }



}
