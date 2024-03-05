using Dal.DalApi;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
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

    }
}
