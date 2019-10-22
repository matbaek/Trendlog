using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trendlog.Models;

namespace Trendlog.Models
{
    public class TrendlogContext : DbContext
    {
        public TrendlogContext (DbContextOptions<TrendlogContext> options)
            : base(options)
        {
        }

        public DbSet<Trendlog.Models.User> User { get; set; }

        public DbSet<Trendlog.Models.Bandwidth> Bandwidth { get; set; }
    }
}
