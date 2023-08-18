using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class BaseClass
    {
        public int Id { get; set; }
        public BaseClass(int id)
        {
            this.Id = id;
        }
        public BaseClass()
        {

        }
    }
}