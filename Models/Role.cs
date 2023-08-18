using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public Role(int id, string name, string description) : base(id)
        {
            this.Name = name;
            this.Description = description;
        }
        public Role()
        {

        }
    }
}