using DefineUserRole.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using ViewModels;

namespace DefineUserRole.Controllers
{
    [Route("api/Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public RoleService RoleService { get; set; } = new RoleService();

        [Route("Read")]
        [HttpGet]
        public List<RoleViewModel> Get()
        {
            return RoleService.Read();
        }

        [Route("Create")]
        [HttpPost]
        public void Post(RoleModel value)
        {
            RoleService.Create(value.Id, value.Name, value.Description);
        }

        [Route("Update")]
        [HttpPut]
        public void Put(RoleModel value)
        {
            RoleService.Update(value.Id, value.Name, value.Description);
        }

        [Route("Delete")]
        [HttpDelete]
        public void Delete(int Id)
        {
            RoleService.Delete(Id);
        }

        [Route("AddRoleToUser")]
        [HttpPut]
        public void AddRoleToUser(int roleId, int userId)
        {
            RoleService.AddRoleToUser(roleId, userId);
        }

        [Route("DeleteRoleToUser")]
        [HttpDelete]
        public void DeleteRoleToUser(int roleId, int userId)
        {
            RoleService.DeleteRoleToUser(roleId, userId);
        }

        [Route("GetRoleOfUser")]
        [HttpGet]
        public List<Role> GetRoleOfUser(int id)
        {
            return RoleService.GetRoleOfUsers(id);
        }
    }
}