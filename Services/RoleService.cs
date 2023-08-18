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
    public class RoleService : IRoleService
    {
        public UserService UserService { get; set; } = new UserService();
        public DefineUserRoleContext dbContext { get; set; }
        public RoleService()
        {
            string ConnectionString = "Data Source=DESKTOP-JLPQILD; Initial Catalog=DefineUserRole; Persist Security Info=True;User ID=sa;Password=3861438178_Kaisoo8812";
            dbContext = new DefineUserRoleContext(ConnectionString);
        }
        public List<Role> Read()
        {
            List<Role> allRoles = dbContext.Roles.ToList();
            if (allRoles.Count == 0)
            {
                Console.WriteLine("The list has no values. Please add some to it.");
            }
            return allRoles;
        }
        public void Create(int id, string name, string description)
        {
            dbContext.Roles.Add(new Role(id, name, description));
            dbContext.SaveChanges();
        }
        public void Update(int id, string name, string description)
        {
            Role role = GetById(id);
            if (role != null)
            {
                role.Name = name;
                role.Description = description;
                dbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Role role = GetById(id);
            if (role != null)
            {
                dbContext.Roles.Remove(role);
                dbContext.SaveChanges();
            }
        }
        public Role GetById(int id)
        {
            return dbContext.Roles.SingleOrDefault(role => role.Id == id);
        }
        public void AddRoleToUser(int roleId, int userId)
        {
            //پیدا کردن موقعیت
            Role currentRole = GetById(roleId);

            //پیدا کردن کاربر 
            User currentUser = UserService.GetById(userId);

            //اد کردن موقعیت به کاربر
            currentRole.UserId = userId;
            dbContext.SaveChanges();
        }
        public void DeleteRoleToUser(int roleId, int userId)
        {
            //پیدا کردن موقعیت
            Role currentRole = GetById(roleId);

            //پیدا کردن کاربر 
            User currentUser = UserService.GetById(userId);

            //دیلیت کردن موقعیت از کاربر
            dbContext.Roles.Remove(currentRole);
            dbContext.SaveChanges();
        }
        public List<Role> GetRoleOfUsers(int id)
        {
            return dbContext.Roles.Where(t => t.UserId == id).ToList();
        }
    }
}