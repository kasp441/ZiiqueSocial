using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class UserDataDto
    { 
        public Profile Profile { get; set; } 
        public List<Post> Posts { get; set; } 
        public List<Follows> Follows { get; set; } 
    }
}
