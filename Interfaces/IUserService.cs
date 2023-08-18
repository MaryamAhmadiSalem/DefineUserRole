using Base;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserService : IRoleAndUser
    {
        public List<User> Read();
        public void Create(int id, string name, string lastName, string userName, string password, long dataOfBirth);
        public void Update(int id, string name, string lastName, string userName, string password, long dataOfBirth);
    }
}
