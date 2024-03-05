using Dal.DalApi;
using Dal.DalImplementation;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VolunteersController : ControllerBase
{
    IRepositoryLess<Volunteer> _volunteer;

    [HttpGet]
    public async Task<List<Volunteer>> GetAllAsync()
    {
        return await _volunteer.GetAllAsync();
    }
    [HttpGet]
    public async Task<Volunteer> GetSingleAsync(string id)
    {
        return await _volunteer.GetSingleAsync(id);
    }
    [HttpPut]
    public Task<Volunteer> PutAsync(int id, Volunteer item)
    {
        return _volunteer.PutAsync(id, item);
    }

    [HttpPost]
    public async Task<Volunteer> PostAsync(Volunteer entity)
    {
        return await _volunteer.PostAsync(entity);
    }

}
