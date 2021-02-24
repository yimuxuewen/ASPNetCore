using MicroService.IService;
using MicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MicroService.Service
{
    public class UserService : IUserService
    {
        List<User> _UserList = new List<User>()
        {
            new User()
            {
                Id=1,
                Account="Administrator",
                Email="Administrator@sina.com",
                Name="Asp",
                Password="123",
                LoginTime=DateTime.Now,
                Role="Admin"
            },
            new User()
            {
                Id=2,
                Account="Guest",
                Email="Guest@sina.com",
                Name="Guest",
                Password="434",
                LoginTime=DateTime.Now,
                Role="Guest"
            },
            new User()
            {
                Id=3,
                Account="Apple",
                Email="Apple@sina.com",
                Name="Apple",
                Password="434",
                LoginTime=DateTime.Now,
                Role="Apple"
            },
            new User()
            {
                Id=4,
                Account="Android",
                Email="Android@sina.com",
                Name="Android",
                Password="434",
                LoginTime=DateTime.Now,
                Role="Android"
            }
        };
        public User FindUser(int id)
        {
            return _UserList.Find(u => u.Id == id);
        }

        public IEnumerable<User> UserAll()
        {
            return _UserList;
        }
    }
}
