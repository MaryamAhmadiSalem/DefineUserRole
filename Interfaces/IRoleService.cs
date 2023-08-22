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
    public interface IRoleService : IRoleAndUser
    {
        public List<RoleViewModel> Read();
        public void Create(int id, string name, string description);
        public void Update(int id, string name, string description);
        public void AddRoleToUser(int roleId, int userId);
        public void DeleteRoleToUser(int roleId, int userId);
        public List<Role> GetRoleOfUsers(int id);
    }
}
