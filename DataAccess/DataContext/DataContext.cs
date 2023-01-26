using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContext
{
    public class DbDataContext : DbContext
    {
        public DbDataContext(){ }
        public DbDataContext(DbContextOptions<DbContext> options) : base(options) { }

        DbSet<Company> Companies { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = enoca; Trusted_Connection = True; TrustServerCertificate = True;");
        }
    }
}
