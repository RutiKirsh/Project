using Bl;
using Bl.BlApi;
using Bl.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userRepo;
        public UsersController(BlManager blManager) {
            this._userRepo = blManager.userService;
        }
        [HttpGet("{email}")]
        public async Task<bool> EmailExist(string email)
        {
            return await _userRepo.EmailExist(email);
        }
        [HttpGet("{email}/{password}")]
        public async Task<BlUser> GetUser(string email, string password)
        {
            return await _userRepo.GetUser(email, password);
        }
    }
}
