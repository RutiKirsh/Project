using Bl;
using Bl.BlApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepo _userRepo;
        public UsersController(BlManager blManager) {
            this._userRepo = blManager.userService;
        }
        [HttpGet("{email}")]
        public async Task<bool> EmailExist(string email)
        {
            return await _userRepo.EmailExist(email);
        }
    }
}
