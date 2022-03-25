using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace BtcTrader.Infrastructure.Context
{
    public class BtcTraderContextFactory : IDesignTimeDbContextFactory<BtcTraderContext>
    {
        private readonly IConfiguration Configuration;
        public BtcTraderContextFactory()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public BtcTraderContext CreateDbContext(params string[] args)
        {
            var connectionString = Configuration.GetConnectionString("DbConnection");
            var builder = new DbContextOptionsBuilder<BtcTraderContext>();
            builder.UseNpgsql(connectionString);
            return new BtcTraderContext(builder.Options);
        }
        /// <summary>
        /// Uygulama ayağa kalkarken Dependency injection yapıldıktan sonra çalışmayan migrationlar için eklenmiştir. Uygulama ilk çalıştırmada DB ve Tablo oluşturması
        /// </summary>
        public void Migrate()
        {
            using (var context = this.CreateDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
