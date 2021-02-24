using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroService.IService;
using MicroService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroServiceInstance.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _configuration = configuration;
            _userService = userService;
        }
        // GET: /<controller>/

        [Route("GET")]
        public User Get(int id)
        {
            return _userService.FindUser(id);
        }

        [Route("ALL")]
        public IEnumerable<User> Get()
        {
            Console.WriteLine($"This is UsersController {_configuration["port"]} Invoke");
            return _userService.UserAll().Select(u=>new User()
            {
                Id = u.Id,
                Name = u.Name,
                Account = u.Account,
                Password = u.Password,
                Email = u.Email,
                Role = u.Role +"_" + _configuration["port"],
                LoginTime=u.LoginTime
            });
        }
    }
}
