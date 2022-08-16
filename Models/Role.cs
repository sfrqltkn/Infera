using Infera_WebApi.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infera_WebApi.Models
{
    public class Role : BaseModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        //UserRole sınıfını kullanarak bir koleksiyon oluşturduk. 
    }
}
