using Infera_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Infera_WebApi.Context
{
    public class SqlServerDbContext:DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> opt): base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
