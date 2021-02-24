using MicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.IService
{
    public interface IUserService
    {
        public User FindUser(int id);

        public IEnumerable<User> UserAll();
    }
}
