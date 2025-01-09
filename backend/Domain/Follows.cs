using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Follows
    {
        public int Id { get; set; }
        public Guid profile { get; set; }
        public Guid follows { get; set; }
    }
}
