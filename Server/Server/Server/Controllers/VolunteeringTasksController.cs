using Dal.DalApi;
using Dal.DalImplementation;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VolunteeringTasksController : ControllerBase
{
    IRepository<VolunteeringTask> _volunteeringTasksRepository;
    public VolunteeringTasksController(IRepository<VolunteeringTask> repository)
    {
        this._volunteeringTasksRepository = repository;
    }
    [HttpGet]
    public async Task<List<VolunteeringTask>> GetAllAsync()
    {
        return await _volunteeringTasksRepository.GetAllAsync();
    }
    [HttpGet]
    public async Task<VolunteeringTask> GetSingleAsync(int id)
    {
        return await _volunteeringTasksRepository.GetSingleAsync(id);
    }
    [HttpPost]
    public async Task<VolunteeringTask> PostAsync(VolunteeringTask entity)
    {
        return await _volunteeringTasksRepository.PostAsync(entity);
    }
    [HttpPut]
    public async Task<VolunteeringTask> PutAsync(int id, VolunteeringTask item)
    {
        return await _volunteeringTasksRepository.PutAsync(id, item);
    }
    [HttpDelete]
    public async Task<VolunteeringTask> DeleteAsync(int id)
    {
        return await _volunteeringTasksRepository.DeleteAsync(id);
    }



}
