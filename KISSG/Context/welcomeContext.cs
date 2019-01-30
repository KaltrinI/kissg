using KISSG.Templates.OnePageSite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KISSG.Context
{
    public class welcomeContext : DbContext
    {
        public welcomeContext(DbContextOptions<welcomeContext> options) : base(options)
        {

        }

        public DbSet<welcome> Welcomes { get; set; }
    }
}
