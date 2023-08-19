using DatabaseContainer;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<User> Read()
        {
            List<User> allUsers = dbContext.Users.ToList();
            if (allUsers.Count == 0)
            {
                Console.WriteLine("The list has no values. Please add some to it.");
            }
            return allUsers;
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
        public User GetById(int id)
        {
            return dbContext.Users.SingleOrDefault(user => user.Id == id);
        }
    }
}