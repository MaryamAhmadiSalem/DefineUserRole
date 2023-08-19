using DatabaseContainer;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public class UserService : IUserService
    {
        public DefineUserRoleContext dbContext { get; set; }
        public UserService()
        {
            string ConnectionString = "Data Source=DESKTOP-JLPQILD; Initial Catalog=DefineUserRole; Persist Security Info=True;User ID=sa;Password=3861438178_Kaisoo8812";
            dbContext = new DefineUserRoleContext(ConnectionString);
        }
        public List<UserViewModel> Read()
        {
            //List<User> allUsers = dbContext.Users.ToList();
            //List<UserViewModel> userModels = new List<UserViewModel>();
            //foreach (var user in allUsers)
            //{
            //    userModels.Add(new UserViewModel()
            //    {
            //        Id = user.Id,
            //        Name = user.Name,
            //        LastName = user.LastName,
            //        UserName = user.UserName,
            //        Password = user.Password,
            //        Age = this.CalculateAge(user.DataOfBirth)
            //    });
            //}
            return dbContext.Users.Select(user => new UserViewModel()
            {
                Id = user.Id,
                FullName = user.Name + " " + user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                Age = DateTime.Now.Year - user.DataOfBirth.Year
            }).ToList();
            //var x = dbContext.Users.Select(user => user.Name).ToList();
            //return userModels;
        }
        public void Create(int id, string name, string lastName, string userName, string password, DateTime dataOfBirth)
        {
            dbContext.Users.Add(new User(id, name, lastName, userName, password, dataOfBirth));
            dbContext.SaveChanges();
        }
        public void Update(int id, string name, string lastName, string userName, string password, DateTime dataOfBirth)
        {
            User user = this.GetById(id);
            if (user != null)
            {
                user.Name = name;
                user.LastName = lastName;
                user.UserName = userName;
                user.Password = password;
                user.DataOfBirth = dataOfBirth;
                dbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            User user = this.GetById(id);
            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }
        //private int CalculateAge(DateTime dataOfBirth)
        //{
        //    //تفریق تاریخ تولد کاربر از تاریخ روز
        //    int age = DateTime.Now.Year - dataOfBirth.Year;

        //    //برگرداندن سن
        //    return age;
        //}
        public User GetById(int id)
        {
            return dbContext.Users.SingleOrDefault(user => user.Id == id);
        }
    }
}