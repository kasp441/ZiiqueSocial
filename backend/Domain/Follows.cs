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
        public virtual Profile profile { get; set; }
        public virtual Profile follows { get; set; }
    }
}
