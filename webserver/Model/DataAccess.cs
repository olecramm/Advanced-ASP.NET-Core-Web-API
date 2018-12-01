using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webserver.Model
{
    public class SakilaDbContext : DbContext
    {
        public SakilaDbContext(DbContextOptions<SakilaDbContext> options)
        :base(options)
        {
        }
        public DbSet<Actor> Actor { get; set; }
    }

    public class SakilaDbContextFactory
    {
        public static SakilaDbContext Create(string connectionString)
        {
            var optionBuilder = new DbContextOptionsBuilder<SakilaDbContext>();
            optionBuilder.UseMySQL(connectionString);
            var sakilaDbContext = new SakilaDbContext(optionBuilder.Options);
            return sakilaDbContext;
        }
    }
}
