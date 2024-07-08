using Bl;
using Bl.BlImplementaion;
using Bl.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        InfoService service;
        public InfoController(BlManager blManager)
        {
            this.service = blManager.infoService;
        }
        [HttpGet("challenges")]
        public List<string> GetChallenges()
        {
            return service.GetChallenges();
        }
    }
}
