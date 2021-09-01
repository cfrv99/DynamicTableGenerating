using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicTable.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableHeader> TableHeaders { get; set; }
        public DbSet<TableValue> TableValues { get; set; }
    }
}
