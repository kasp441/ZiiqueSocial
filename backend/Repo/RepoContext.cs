using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class RepoContext : DbContext
    {

        //db sets here

        public RepoContext(DbContextOptions<RepoContext> options) : base(options)
        {
        }
    }
}
