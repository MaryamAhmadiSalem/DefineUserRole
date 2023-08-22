using Base;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Interfaces
{
    public interface IUserService : IRoleAndUser
    {
        public List<UserViewModel> Read();
        public void Create(int id, string name, string lastName, string userName, string password, DateTime dataOfBirth);
        public void Update(int id, string name, string lastName, string userName, string password, DateTime dataOfBirth);
    }
}