using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MJKProjectsDAL.EF.Factories
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(@Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MJKProjectsClient/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
#if DEBUG
            var connectionString = configuration.GetConnectionString("DevConnection");
#else            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
#endif
            builder.UseNpgsql(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
