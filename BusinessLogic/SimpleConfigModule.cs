using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Model;
using Ninject.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogic
{
    public class SimpleConfigModule:NinjectModule
    {
        public override void Load()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string framework = configuration["DataAccessFramework"];
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // DBContext для EF
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            Bind<DbContextOptions<AppDbContext>>().ToConstant(optionsBuilder.Options);
            Bind<AppDbContext>().ToSelf().InSingletonScope();

            
            switch (framework)
            {
                case "Dapper":
                    Bind<IRepository<Student>>().To<DapperRepository<Student>>().InSingletonScope();
                    break;
                case "EntityFramework":
                    Bind<IRepository<Student>>().To<EFRepository<Student>>().InSingletonScope();
                    break;
                default:
                    throw new ArgumentException("Неподдерживаемый фреймворк доступа к данным");
            }
        }
    }
}
