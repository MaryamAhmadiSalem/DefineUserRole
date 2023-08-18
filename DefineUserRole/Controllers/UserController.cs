using DefineUserRole.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace DefineUserRole.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserService UserService { get; set; } = new UserService();

        [Route("Read")]
        [HttpGet]
        public List<User> Get()
        {
            return UserService.Read();
        }

        [Route("Create")]
        [HttpPost]
        public void Post(UserModel value)
        {
            UserService.Create(value.Id, value.Name, value.LastName, value.UserName, value.Password, value.DataOfBirth);
        }

        [Route("Update")]
        [HttpPut]
        public void Put(UserModel value)
        {
            UserService.Update(value.Id, value.Name, value.LastName, value.UserName, value.Password, value.DataOfBirth);
        }

        [Route("Delete")]
        [HttpDelete]
        public void Delete(int Id)
        {
            UserService.Delete(Id);
        }
    }
}
