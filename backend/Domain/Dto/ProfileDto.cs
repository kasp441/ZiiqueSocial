using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ProfileDto
    {
        public string username { get; set; }
        public string displayName { get; set; }
        public string profileIcon { get; set; }
        public DateTime StartedAt { get; set; }
        public string bio { get; set; }
    }
}
