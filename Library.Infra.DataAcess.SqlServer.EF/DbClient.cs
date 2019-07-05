using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infra.DataAcess.SqlServer.EF
{
    public class DbClient : DbContext
    {
        public readonly IConfiguration _configuration = null;

        public DbClient()
        {
            _configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
        }

        public DbClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

    }
}
