using Bl;
using Bl.BlApi;
using Bl.Models;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VolunteersController : ControllerBase
{
    IVolunteersRepo _volunteer;
    public VolunteersController(BlManager manager)
    {
        _volunteer = manager.volunteersService;
    }

    [HttpGet]
    public async Task<PagedList<BlVolunteer>> GetAllAsync([FromQuery] BaseQueryParams queryParams)
    {
        return await _volunteer.GetAllAsync(queryParams);
    }
    [HttpGet("{id}")]
    public async Task<BlVolunteer> GetSingleAsync(string id, [FromBody] BlUser user)
    {
        return await _volunteer.GetSingleAsync(id, user);
    }
    [HttpPut("{id}")]
    public Task<BlVolunteer> PutAsync(BlVolunteer item, BlUser user)
    {
        return _volunteer.PutAsync(item, user);
    }

    [HttpPost]
    public async Task<BlVolunteer> PostAsync(BlVolunteer entity)
    {
        return await _volunteer.PostAsync(entity);
    }

}
