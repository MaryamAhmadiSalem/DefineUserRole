using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : BaseClass
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DataOfBirth { get; set; }
        public List<Role> Roles { get; set; }
        public User(int id, string name, string lastName, string userName, string password, DateTime dataOfBirth) : base(id)
        {
            this.Name = name;
            this.LastName = lastName;
            this.UserName = userName;
            this.Password = password;
            this.DataOfBirth = dataOfBirth;
        }
        public User()
        {

        }
    }
}