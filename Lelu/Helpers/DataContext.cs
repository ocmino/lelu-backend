using Lelu.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lelu.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _config;

        public DataContext(IConfiguration config, DbContextOptions<DataContext> options) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_config.GetConnectionString("DB"));
        }

        public DbSet<Model> Models { get; set; }

    }
}